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
    public class UnitTest1
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

        [Test]
        public void TestMethod1()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/login.php");
            if ((IsElementExists(By.Name("username")) == true) && (IsElementExists(By.Name("password")) == true))
            {
                IWebElement LohinInput = Browser.FindElement(By.Name("username"));
                IWebElement PasswordInput = Browser.FindElement(By.Name("password"));
                LohinInput.SendKeys("admin");
                PasswordInput.SendKeys("admin" + OpenQA.Selenium.Keys.Enter);
            }
            else
            {
                throw new ArgumentException("Нет полей для ввода");
            }


           // Thread.Sleep(5000);
            List<IWebElement> href = Browser.FindElements(By.CssSelector("#app-")).ToList();
            for (int i = 0; i < href.Count; i++)
            {

                Browser.FindElements(By.CssSelector("#app- > a"))[i].Click();


                List<IWebElement> iii = Browser.FindElements(By.CssSelector(".docs li")).ToList();
                for (int j = 0; j < iii.Count; j++)
                {
                    Browser.FindElements(By.CssSelector(".docs li"))[j].Click();
                    IWebElement qqq = Browser.FindElement(By.CssSelector("#content> h1"));
                    string s = qqq.GetAttribute("innerText");

                    if (s.Length == 0)
                    {
                        throw new ArgumentException("пустой заголовок");
                    }
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
