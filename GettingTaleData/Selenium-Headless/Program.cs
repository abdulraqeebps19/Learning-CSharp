using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{
    static void Main()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");

        using (IWebDriver driver = new ChromeDriver(options))
        {
            string url = "https://learn.microsoft.com/en-us/troubleshoot/sql/releases/download-and-install-latest-updates#latest-updates-available-for-currently-supported-versions-of-sql-server";
            driver.Navigate().GoToUrl(url);

            IWebElement table = driver.FindElement(By.XPath("//table[@aria-label='Table 1']"));
            var tableRows = table.FindElements(By.TagName("tr"));
            String strRowData = "";

            // Traverse each row
            foreach (var elemTr in tableRows)
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
                    Console.WriteLine(tableRows[0].Text.Replace(" ", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = String.Empty;
            }
            Console.WriteLine("");
            driver.Quit();
        }
    }
}
