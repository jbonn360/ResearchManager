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

        public List<string> GetDataFromHydi(string uri)
        {            
            bool done = false;
            int recordLimit = 100;
            try{
                recordLimit = Convert.ToInt32(ConfigurationManager.AppSettings["hydi.search.limit"]);
            }catch(FormatException e){
                Console.WriteLine("Invalid value entered for hydi.search.limit, defaulting to: " + recordLimit);
            }
            
            List<string> result = new List<string>();

            //Total records found for current search
            int totalRecordsFound = 0;

            //While not done with the whole search
            while (!done)
            {
                // Initialising driver
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                driver = new ChromeDriver(options);   

                //Gathering and adding the data retrieved from the this loop
                result.AddRange(GetDataFromHyDi(uri, driver, ref totalRecordsFound, ref done, recordLimit));

                //Closing chrome driver - must be done AFTER driver objects are no longer needed
                driver.Quit();

                if(!done)
                {
                    //increment offset in uri by limit
                    var uriParameters = HttpUtility.ParseQueryString(uri);
                    int curOffset = Convert.ToInt32(uriParameters.Get("offset"));
                    uri = uri.Replace("&offset=" + curOffset, "&offset=" + totalRecordsFound);
                }
            }

            return result;
            
        }
        private List<string> GetDataFromHyDi(string uri, IWebDriver driver, ref int totalRecordsFound, ref bool done, int recordLimit)
        {           
            //Go to page
            driver.Navigate().GoToUrl(uri);

            string loadMoreResultsBtnXPath = "//*[contains(text(), 'Load more results')]";
            bool brokeLoop = false;

            //Slack time in MS
            int slack = 5000;

            //Wait until either the 'Load more results' button loads, or until 15 seconds pass by
            WebDriverWait waitLoadMoreResultsBtnLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(30));           
            waitLoadMoreResultsBtnLoad.Until((d) => { return d.FindElements(By.XPath(loadMoreResultsBtnXPath)).Count > 0; });
            Thread.Sleep(slack);

            IWebElement loadMoreResultsBtn = driver.FindElement(By.XPath(loadMoreResultsBtnXPath));

            //Getting the total search results found by the search engine
            IWebElement lblResCount = driver.FindElement(By.ClassName("results-count"));

            //Removing the 'Results' section of label text. Example: 230 Results => 230
            string totalResultsFoundStr = lblResCount.Text.Replace("Results", "");

            //Parsing value
            int totalSearchResults = Convert.ToInt32(totalResultsFoundStr);

            //The total search results for this iteration
            int searchResultsLeft = totalSearchResults - totalRecordsFound;

            //Keep loading more records until we reach the final record
            WebDriverWait waitResultsLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            int totalRecordsAfterClick = 0;

            //while (driver.FindElements(By.XPath(loadMoreResultsBtnXPath)).Count > 0)
            while (totalRecordsAfterClick < searchResultsLeft)
            {
                //Getting current number of loaded records
                //int curRecordsFound = driver.FindElements(By.ClassName("item-title")).Count;

                //Stop current session if we are at the record limit, in order to manage memory usage
                //if (curRecordsFound >= recordLimit)
                //set to -5 because of inconsistencies
                if (totalRecordsAfterClick > recordLimit)
                {
                    brokeLoop = true;
                    break;
                }

                //Click button and take count of the new amount of records
                loadMoreResultsBtn.Click();

                //if we're within 20 records or less from the last record
                //wait until you take count of total records after click
                //to deal with 'Load more reusults' button inconsistency at last record
                if((totalRecordsFound + totalRecordsAfterClick) >= (totalSearchResults - 20))                
                    Thread.Sleep(slack);                       
                totalRecordsAfterClick = driver.FindElements(By.ClassName("item-title")).Count;

                //Test - remove me
                if(totalRecordsAfterClick >= 80)
                {
                    Console.WriteLine("");
                }
                //End test
                
                //if we haven't reached the last record
                if(totalRecordsAfterClick < searchResultsLeft)
                {
                    //Wait for new records to load and for Load more results' button to re-appear
                    waitResultsLoad.Until((d) =>
                    {
                        return
                        ((d.FindElements(By.XPath(loadMoreResultsBtnXPath)).Count > 0));
                    });
                    Thread.Sleep(slack);
                }else
                {
                    break;
                }                
                
            }
            Thread.Sleep(slack);

            //Fetching all elements with study titles
            IReadOnlyCollection<IWebElement> records = driver.FindElements(By.ClassName("item-title"));

            //Aggregating all the record titles into a list
            List<string> result = new List<string>();
            foreach(var record in records)
            {
                result.Add(record.Text);
                totalRecordsFound++;
            }

            //IF we made it all the way here without breaking the loop,
            //it means that we have reached the last record
            if (!brokeLoop)
                done = true;

            return result;
        }

        public List<string> GetDataFromPubMed(string uri)
        {
            return null;
        }

        public List<string> GetDataFromScholar(string uri)
        {
            return null;
        }

    }
}
