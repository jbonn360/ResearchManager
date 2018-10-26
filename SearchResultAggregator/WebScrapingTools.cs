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

        public List<string> GetDataFromHyDi(string uri)
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
            int totalSearchResults = Convert.ToInt32(totalResultsFoundStr);

            //While we haven't retrieved all the records
            while (result.Count < totalSearchResults)
            {
                //Wait a flat 2 seconds for values to be reset after the re-navigate
                Thread.Sleep(2000);

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

        public List<string> GetDataFromPubMed(string uri)
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
                        //Show error
                        break;
                    }
                    
                }
            }
            return result;

        }

        public List<string> GetDataFromScholar(string uri)
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
            return result;
        }

        private void InitChromeBrowser()
        {
            // Initialising driver
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
        }

    }
}
