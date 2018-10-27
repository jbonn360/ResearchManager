using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NHtmlUnit;
using System.Threading;
using System.Web;
using System.Configuration;

namespace SearchResultAggregator
{
    public class WebScrapingTools
    {
        IWebDriver driver;
        public WebScrapingTools()
        {
           
        }

        public List<string> GetDataFromHyDi(string uri, ref string errorMessage)
        {
            InitChromeBrowser();

            List<string> result = new List<string>();

            //Navigating to the uri for the first time
            driver.Navigate().GoToUrl(uri);

            //Waiting for results label to load
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                d => { return d.FindElements(By.ClassName("results-count")).Count > 0; });

            IWebElement lblResCount = driver.FindElement(By.ClassName("results-count"));

            //Removing the 'Results' section of label text. Example: 230 Results => 230
            string totalResultsFoundStr = lblResCount.Text.Replace("Results", "");
            //Parsing value
            int totalSearchResults = 0;
            try
            {
                totalSearchResults = Convert.ToInt32(totalResultsFoundStr);
            }catch(FormatException e)
            {
                errorMessage += "Error: Could not parse total search results string on: " 
                    + new Uri(uri).Host + ", value is: " + totalSearchResults + "\n";
            }

            int slack = 2;
            string slackString = ConfigurationManager.AppSettings["SlackInSeconds"];
            if (String.IsNullOrEmpty(slackString))
                slackString = "2";

            try
            {
                slack = Convert.ToInt32(slackString) * 1000;
            }catch(FormatException)
            {
                errorMessage += "Error: Could not parse slack time value: " + slackString + ", please configure this correctly in App.config.\n";
            }

            //While we haven't retrieved all the records
            while (result.Count < totalSearchResults)
            {
                //Allow some slack to cater for slow computers
                Thread.Sleep(slack);

                //Gathering and adding the data chunk retrieved from the this loop
                List<string> currentChunk = GetDataChunkFromHyDi(uri);

                //Adding current chunk to main list
                result.AddRange(currentChunk);

                //Navigate to the new chunk of results
                if (result.Count < totalSearchResults)
                {
                    //increment offset in uri by limit
                    var uriParameters = HttpUtility.ParseQueryString(uri);
                    int curOffset = Convert.ToInt32(uriParameters.Get("offset"));
                    uri = uri.Replace("&offset=" + curOffset, "&offset=" + result.Count);
                    //Go to page
                    driver.Navigate().GoToUrl(uri);                    
                }

            }
            //Close browser
            driver.Quit();

            if(result.Count <= 0)            
                errorMessage += "Error: No search results found for search with host " + new Uri(uri).Host + "\n";

            return result;
        }

        private List<string> GetDataChunkFromHyDi(string uri)
        {
            //Waiting for records to load
            WebDriverWait waitRecordsLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IReadOnlyCollection<IWebElement> records = 
                waitRecordsLoad.Until((d) => { return d.FindElements(By.ClassName("item-title")); });

            //Aggregating all the record titles into a list
            List <string> result = new List<string>();
            foreach (var record in records)
            {
                result.Add(record.Text);
            }

            return result;
        }

        public List<string> GetDataFromPubMed(string uri, PubMedOptions options, ref string errorMessage)
        {
            InitChromeBrowser();

            //Go to page
            driver.Navigate().GoToUrl(uri);

            //Wait for first page to load
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            //Setting filters
            TacklePubMedFilters(options);

            //Wait for page to load
            new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                    .Until(d => ((IJavaScriptExecutor)d)
                                .ExecuteScript("return document.readyState").Equals("complete"));

            List<string> result = new List<string>();

            
            WebDriverWait waitResultsLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            bool lastPage = false;

            IWebElement nextPageLink = null;

            //Looping through all the pages
            while (!lastPage)
            {
                //Wait for results to load, once they load, retrieves ALL the results on the page
                IReadOnlyCollection<IWebElement> records = waitResultsLoad.Until((d) => { return ((d.FindElements(By.ClassName("rslt")))); });
                foreach (var record in records)
                {
                    string recordTitle = "";
                    recordTitle = record.FindElement(By.ClassName("title")).FindElement(By.TagName("a")).Text;
                    result.Add(recordTitle);
                }

                //Checking if we're at the last page
                if (driver.FindElements(By.CssSelector(".inactive.page_link.next")).Count > 0
                    && driver.FindElements(By.CssSelector(".active.page_link.next")).Count <= 0){
                    lastPage = true;
                    break;
                }
                else
                {
                    //Getting 'Next>' link, if it exists, and clicking it
                    if(driver.FindElements(By.CssSelector(".active.page_link.next")).Count > 0)
                    {
                        nextPageLink = driver.FindElement(By.CssSelector(".active.page_link.next"));
                        nextPageLink.Click();
                    }
                    else
                    {
                        errorMessage += "Error: Could not locate 'Next' button on: " + new Uri(uri).Host + "\n";
                        break;
                    }
                    
                }
            }

            driver.Quit();

            if (result.Count <= 0)
                errorMessage += "Error: No search results found for search with host " + new Uri(uri).Host + "\n";

            return result;

        }

        public List<string> GetDataFromScholar(string uri, ref string errorMessage)
        {
            InitChromeBrowser();

            //Go to page
            driver.Navigate().GoToUrl(uri);

            List<string> result = new List<string>();

            WebDriverWait waitResultsLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            bool lastPage = false;

            IWebElement nextPageLink = null;

            //Looping through all the pages
            while (!lastPage)
            {
                //Wait for results to load, once they load, retrieves ALL the results on the page
                IReadOnlyCollection<IWebElement> records = waitResultsLoad.Until((d) => { return ((d.FindElements(By.CssSelector(".gs_r.gs_or.gs_scl")))); });
                foreach (var record in records)
                {
                    string recordTitle = "";
                    IWebElement titleContainer = record.FindElement(By.ClassName("gs_ri")).FindElement(By.ClassName("gs_rt"));

                    
                    if(titleContainer.FindElements(By.TagName("a")).Count > 0)
                    {
                        //If source is a book/journal/article etc..
                        recordTitle = titleContainer.FindElement(By.TagName("a")).Text;
                    }
                    else
                    {
                        //If it is a citation, it won't have a link, so just grab the text 
                        //and remove the '[CITATION] ' tag
                        recordTitle = titleContainer.Text.Replace("[CITATION] ", "");
                        recordTitle = recordTitle + " [CITATION]";
                    }
                        
                    result.Add(recordTitle);
                }

                IWebElement navigationDiv = driver.FindElement(By.Id("gs_n"));


                //Checking if we're at the last page
                if (navigationDiv.FindElements(By.CssSelector(".gs_ico.gs_ico_nav_next")).Count > 0)
                {
                    nextPageLink = navigationDiv.FindElement(By.CssSelector(".gs_ico.gs_ico_nav_next"));
                    nextPageLink.Click();
                }
                else
                {
                    lastPage = true;
                    break;
                }
            }

            driver.Quit();

            if (result.Count <= 0)
                errorMessage += "Error: No search results found for search with host " + new Uri(uri).Host + "\n";

            return result;
        }

        private void InitChromeBrowser()
        {
            // Initialising driver
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
        }

        private void TacklePubMedFilters(PubMedOptions options)
        {
            //Wait for filters section to load
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d =>  driver.FindElements(By.Id("faceted_search")).Count > 0);

            //Activate filters
            if (options.Abstract)            
                ClickFilterLink("Abstract");

            if (options.FreeFullText)            
                ClickFilterLink("Free full text");           
                
            if (options.FullText)            
                ClickFilterLink("Full text");

            if (options.Humans)            
                ClickFilterLink("Humans"); 
    
            if (options.OtherAnimals)
                ClickFilterLink("Other Animals"); 

            if (options.PublicationFrom != DateTime.MinValue && options.PublicationTo != DateTime.MinValue)
            {
                driver.FindElement(By.Id("faceted_search")).FindElement(By.Id("facet_date_rangeds1")).Click();

                //Wait for prompt to show
                IWebElement datePrompt = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                    .Until((d) => { return d.FindElement(By.Id("facet_date_range_divds1")); });

                //Setting textboxes
                //Year, month, day From     
                datePrompt.FindElement(By.Id("facet_date_st_dayds1")).SendKeys(
                    options.PublicationFrom.Day.ToString());
                datePrompt.FindElement(By.Id("facet_date_st_monthds1")).SendKeys(
                    options.PublicationFrom.Month.ToString());
                datePrompt.FindElement(By.Id("facet_date_st_yeards1")).SendKeys(
                    options.PublicationFrom.Year.ToString());

                //Year, month, day To
                datePrompt.FindElement(By.Id("facet_date_end_dayds1")).SendKeys(
                    options.PublicationTo.Day.ToString());
                datePrompt.FindElement(By.Id("facet_date_end_monthds1")).SendKeys(
                    options.PublicationTo.Month.ToString());
                datePrompt.FindElement(By.Id("facet_date_end_yeards1")).SendKeys(
                    options.PublicationTo.Year.ToString());

                //Clicking 'Apply' button
                datePrompt.FindElement(By.Id("facet_date_range_applyds1")).Click();
            }
        }

        private void ClickFilterLink(string filterLinkText)
        {
            driver.FindElement(By.Id("faceted_search")).FindElement(By.LinkText(filterLinkText)).Click();
        }



    }
}
