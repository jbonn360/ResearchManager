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
            List<string> result = new List<string>();

            while (!done)
            {
                // Initialising driver
                driver = new ChromeDriver();

                result.AddRange(GetDataFromHyDi(uri, driver, ref done, recordLimit));

                //Closing chrome driver - must be done AFTER driver objects are no longer needed
                driver.Quit();

                if(!done)
                {
                    //increment offset in uri by limit
                    var nameValues = HttpUtility.ParseQueryString(uri);
                    int newOffset = Convert.ToInt32(nameValues.Get("offset")) + recordLimit;
                    nameValues.Set("offset", newOffset.ToString());
                    //uri = HttpUtility.
                    //string url = Request.Url.AbsolutePath;
                }
            }

            return result;
            
        }
        private List<string> GetDataFromHyDi(string uri, IWebDriver driver, ref bool done, int recordLimit)
        {           
            //Go to page
            driver.Navigate().GoToUrl(uri);

            string loadMoreResultsBtnXPath = "//*[contains(text(), 'Load more results')]";
            bool brokeLoop = false;

            //Wait until either the 'Load more results' button loads, or until 15 seconds pass by
            WebDriverWait waitLoadMoreResultsBtnLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(60));           
            waitLoadMoreResultsBtnLoad.Until((d) => { return d.FindElements(By.XPath(loadMoreResultsBtnXPath)).Count > 0; });
            Thread.Sleep(10000);

            IWebElement loadMoreResultsBtn = driver.FindElement(By.XPath(loadMoreResultsBtnXPath));

            //Find 'Load More Results' button, if it exists click it
            //Keep doing this until button does not appear (i.e. results have all been loaded)
            WebDriverWait waitResultsLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            while (driver.FindElements(By.XPath(loadMoreResultsBtnXPath)).Count > 0)
            {
                //Getting current number of loaded records
                int curRecordsFound = driver.FindElements(By.ClassName("item-title")).Count;

                if (curRecordsFound >= recordLimit)
                {
                    brokeLoop = true;
                    break;
                }
                    

                loadMoreResultsBtn.Click();

                waitResultsLoad.Until((d) => 
                {
                    return 
                    ((d.FindElements(By.ClassName("item-title")).Count > curRecordsFound)
                        && driver.FindElements(By.XPath(loadMoreResultsBtnXPath)).Count > 0);
                });
                Thread.Sleep(2000);
            }

            //Fetching all elements with study titles
            IReadOnlyCollection<IWebElement> records = driver.FindElements(By.ClassName("item-title"));

            //Aggregating all the record titles into a list
            List<string> result = new List<string>();
            foreach(var record in records)
            {
                result.Add(record.Text);
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
