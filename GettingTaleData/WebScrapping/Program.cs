using System;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        string url = "https://learn.microsoft.com/en-us/troubleshoot/sql/releases/download-and-install-latest-updates#latest-updates-available-for-currently-supported-versions-of-sql-server";

        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);

        var tableRows = doc.DocumentNode.SelectNodes("//table[@aria-label='Table 1']//tr");

        if (tableRows != null)
        {
            foreach (HtmlNode row in tableRows)
            {
                HtmlNodeCollection cells = row.SelectNodes("td");
                if (cells != null)
                {
                    foreach (HtmlNode cell in cells)
                    {
                        Console.WriteLine(cell.InnerText.Trim());
                    }
                }
            }
        }
    }
}
