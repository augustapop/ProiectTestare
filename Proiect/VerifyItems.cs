using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;

namespace Proiect
{
    [TestClass]
    public class VerifyItems:SeleniumTest
    {     

        [TestMethod]
        public void testVerifyTitle()
        {
            driver.FindElement(By.PartialLinkText("Crippled")).Click();
            var description = driver.FindElement(By.CssSelector("#details-description-container > div > span.details-title-text > strong")).Text;
            Assert.AreEqual("Crippled America : How to Make America Great Again", description);
        }

        [TestMethod]
        public void testTakeScreenShot()
        {

            //driver.FindElement(By.CssSelector("body > header > div.row.table > div > div.col.utility-shop > ul > li.map-icon > a")).Click();
            //driver.Navigate().GoToUrl("http://www.booksamillion.com/cart");
            driver.Navigate().GoToUrl("http://www.booksamillion.com/storefinder?id=6474896612022");
           
          // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(9000));
            Thread.Sleep(9000);
            
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            //Use it as you want now
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile("filename11.png", ImageFormat.Png); //use any of the built in image formating
            ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
        }

        [TestMethod]
        public void testSearchCategory()
        {
            driver.FindElement(By.Name("query")).SendKeys("Movies");
            driver.FindElement(By.CssSelector("#search")).Click();
            IWebElement searchName = driver.FindElement(By.PartialLinkText("Movies"));
            Assert.IsTrue(searchName.Text.Contains("Movies"));
        }

        [TestMethod]
        public void testDontAllowedToInsertTwiceSameBook()
        {

            //nu ma lasa sa introduc aceeasi carte de 2 ori           
            driver.FindElement(By.PartialLinkText("Crippled")).Click();
            var sku1 = driver.FindElement(By.CssSelector("#details-description-container > div > span.details-title-text > strong")).Text;
            driver.FindElement(By.CssSelector("#addtocartlink")).Click();
            driver.FindElement(By.CssSelector("#cart > form > div:nth-child(1) > a:nth-child(3) > img")).Click();
            driver.FindElement(By.CssSelector("#addtocartlink")).Click();
            var message = driver.FindElement(By.CssSelector("#info_message_content > li")).Text;
            Assert.AreEqual("Crippled America is already in the cart.", message);
        }

        [TestMethod]
        public void testDropDownList()
        {
         IWebElement element=  driver.FindElement(By.Id("where"));
         element.Click();
         IList<IWebElement> AllDropDownList =    element.FindElements(By.XPath("//option"));
         int DpListCount = AllDropDownList.Count;
         for (int i = 0; i < DpListCount; i++)
            {
                if (AllDropDownList[i].Text == "Movies")
                 {
                    AllDropDownList[i].Click();
                 }
            }            
        }

        [TestMethod]
        public void testOperationOnCart()
        {

            driver.FindElement(By.PartialLinkText("Crippled")).Click();
            var sku = driver.FindElement(By.CssSelector("#details-description-container > div > span.details-title-text > strong")).Text;
            // to see if it is the right book
            Assert.AreEqual("Crippled America : How to Make America Great Again", sku);
            driver.FindElement(By.CssSelector("#addtocartlink")).Click();
            //go back 
            driver.FindElement(By.CssSelector("#cart > form > div:nth-child(1) > a:nth-child(3) > img")).Click();

            //Verify if item added to cart.          
            var book1 = driver.FindElement(By.CssSelector("body > header > div.row.table > div > div.col.utility-shop > ul > li.cart-icon > a")).Text;
            Assert.AreEqual("Cart 1", book1);

            driver.Navigate().GoToUrl("http://www.booksamillion.com/ebooks?id=6476594010728");

            //ad another book to cart
            driver.FindElement(By.PartialLinkText("Cross")).Click();
            //#details-description-container > div > span.details-title-text > strong
            var reagan = driver.FindElement(By.CssSelector("#details-description-container > div > span.details-title-text > strong")).Text;
            Assert.AreEqual("Cross Justice", reagan);
            driver.FindElement(By.CssSelector("#addtocartlink")).Click();
            //go back
            driver.FindElement(By.CssSelector("#cart > form > div:nth-child(1) > a:nth-child(3) > img")).Click();

            //verify if book2 was added to cart
            var numberBook = driver.FindElement(By.CssSelector("body > header > div.row.table > div > div.col.utility-shop > ul > li.cart-icon > a")).Text;
            Assert.AreEqual("Cart 2", numberBook);   
             
        }  
        
    }
}
