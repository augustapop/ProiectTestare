using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
   public class SeleniumTest
    {
       public IWebDriver driver;
      // public string url = "http://www.booksamillion.com/";
       public string url = "http://www.booksamillion.com/ebooks?id=6476594010728";

        [TestInitialize]
        public void TestSetup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
