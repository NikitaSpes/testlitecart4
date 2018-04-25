using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;
using System.Linq;




namespace TestClick
{
    [TestClass]
    public class UnitTest2
    {
        static IWebDriver Browser;
        static WebDriverWait wait;

        [SetUp]
        public void start()
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
        }

        public bool IsElementExists(By iClassName)
        {

            try
            {
                Browser.FindElement(iClassName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool AreElementsPresent(IWebElement web, By iClassName)
        {
            return Browser.FindElements(iClassName).Count > 0;
        }

        [Test]
        public void TestMethod2()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/en/");
            // IWebElement goods = Browser.FindElement(By.CssSelector("#box-category-tree > nav > ul > li > a"));
            // goods.Click();
            int i;

            List<IWebElement> popular = Browser.FindElements(By.CssSelector("#box-most-popular > div > ul > li")).ToList();
            for (i = 0; i < popular.Count; i++)
            {
                IWebElement num1 = Browser.FindElements(By.CssSelector("#box-most-popular > div > ul > li"))[i];
                int q0 = num1.FindElements(By.CssSelector("a.link > div.image-wrapper > div")).Count;

                if (AreElementsPresent(num1, By.CssSelector("a.link > div.image-wrapper > div")) == true)
                {
                    if (num1.FindElements(By.CssSelector("a.link > div.image-wrapper > div")).Count > 1)
                    {
                        throw new ArgumentException("больше одного элемента");
                    }
                }
                else
                {
                    throw new ArgumentException("Нет елемента");
                }
            }

                List<IWebElement> campaigns = Browser.FindElements(By.CssSelector("#box-campaigns > div > ul > li")).ToList();
                for (i = 0; i < campaigns.Count; i++)
                {
                    IWebElement num2 = Browser.FindElements(By.CssSelector("#box-campaigns > div > ul > li"))[i];
                    int q1 = num2.FindElements(By.CssSelector("a.link > div.image-wrapper > div")).Count;

                    if (AreElementsPresent(num2, By.CssSelector("a.link > div.image-wrapper > div")) == true)
                    {
                        if (num2.FindElements(By.CssSelector("a.link > div.image-wrapper > div")).Count > 1)
                        {
                            throw new ArgumentException("больше одного элемента");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Нет елемента");
                    }
                }

                    List<IWebElement> products = Browser.FindElements(By.CssSelector("#box-latest-products > div > ul > li")).ToList();
                    for (i = 0; i < products.Count; i++)
                    {
                        IWebElement num3 = Browser.FindElements(By.CssSelector("#box-latest-products > div > ul > li"))[i];
                        int q2 = num3.FindElements(By.CssSelector("a.link > div.image-wrapper > div")).Count;

                        if (AreElementsPresent(num3, By.CssSelector("a.link > div.image-wrapper > div")) == true)
                        {
                            if (num3.FindElements(By.CssSelector("a.link > div.image-wrapper > div")).Count > 1)
                            {
                                throw new ArgumentException("больше одного элемента");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Нет елемента");
                        }                       

                    }

                

        }


        [TearDown]
        public void stop()
        {
            Browser.Quit();
            Browser = null;
        }

    }
}
