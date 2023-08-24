using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using static System.Collections.Specialized.BitVector32;

namespace SelenimTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open the browser for Automation
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string url = "https://learn.microsoft.com/en-us/troubleshoot/sql/releases/download-and-install-latest-updates#latest-updates-available-for-currently-supported-versions-of-sql-server";
            string tableXPath = "//*[@id=\"main\"]/div[3]/div[5]/table";
            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl(@$"{url}");
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
            
            // xpath of html table
            var elemTable = driver.FindElement(By.XPath(@$"{tableXPath}"));

            // Fetch all Row of the table
            List <IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = String.Empty;
            }
            Console.WriteLine("");
            driver.Quit();
        }
    }
}