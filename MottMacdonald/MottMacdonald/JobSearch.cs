using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace MottMacdonald
{
    internal class JobSearch
    {
        public static void Main(string[] args)
        {
            // Create a driver instance for chromedriver 

            IWebDriver driver = new ChromeDriver(@"D:\Project\MottMacdonald\MottMacdonald\Drivers");

            //Navigate to seach Job page of MottMac
            driver.Navigate().GoToUrl("https://www.mottmac.com/careers/search");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            
            //Maximize the window
            driver.Manage().Window.Maximize();

            //Select Language
            IWebElement selectlang = driver.FindElement(By.XPath("//a[@class='language-dropdownitem js-popup-culture' and text()='Global (English)']"));
            if (selectlang.Displayed)
                selectlang.Click();
            Thread.Sleep(1000);
            //Search for Job Title
            driver.FindElement(By.Id("search-career-search-temp")).SendKeys("Software Technical Lead");
            driver.Manage().Timeouts().PageLoad= TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("//button[contains(@class,'jst-searchBox__button')]")).Click();

            Thread.Sleep(1000);
            //Verify Job title
            String Verifyjob = driver.FindElement(By.XPath("//h6[@class='c-careers-search__title']")).Text;
            Assert.AreEqual("Software Technical Lead", Verifyjob);

            //View Job Details
            driver.FindElement(By.XPath("//a[contains(@class,'c-careers-search__link')]")).Click();
            
            //Close the browser
            driver.Close();
        }
    }
}
