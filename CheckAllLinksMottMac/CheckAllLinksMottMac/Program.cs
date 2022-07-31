using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;

namespace CheckAllLinksMottMac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                IWebDriver driver = new ChromeDriver(@"D:\Project\MottMacdonald\MottMacdonald\Drivers");
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.mottmac.com/");
               
                //Declare Webrequest
                HttpWebRequest re = null;
                var urls = driver.FindElements(By.TagName("a"));
                var count = urls.Count;
                Console.WriteLine("Total Number of links : " +count);
                Console.WriteLine("Checking All the links on MottMac.com :");
                //Loop through all the urls
                foreach (var url in urls)
                {

                if (!(url.Text.Contains("Email") || url.Text == ""))
                {
                    //Get the url
                    re = (HttpWebRequest)WebRequest.Create(url.GetAttribute("href"));
                    try
                    {
                        var response = (HttpWebResponse)re.GetResponse();
                        System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{response.StatusCode}");
                    }
                    catch (WebException e)
                    {
                        var errorResponse = (HttpWebResponse)e.Response;
                        System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{errorResponse.StatusCode}");
                    }
                }
            }

            Console.Read();
            driver.Close();

        }
    }

}
    
