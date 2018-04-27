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
    public class UnitTest3
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
        public void openInNewWindow(String url)
        {
            ((IJavaScriptExecutor)Browser).ExecuteScript("window.open(arguments[0])", url);
        }
        /*  public String openInNewWindow(String url, string name)
          {
              //String name = "some_random_name";
              ((IJavaScriptExecutor)Browser).ExecuteScript("window.open(arguments[0],\"" + name + "\")", url);
              return name;
          }*/
        private string FindWindow(String Url)
        {
            String StartWindow = Browser.CurrentWindowHandle;
            String Result = "";

            for (int i = 0; i < Browser.WindowHandles.Count; i++)
            {
                if (Browser.WindowHandles[i] != StartWindow)
                {
                    Browser.SwitchTo().Window(Browser.WindowHandles[i]);
                    if (Browser.Url.Contains(Url))
                    {
                        Result = Browser.WindowHandles[i];
                        break;
                    }
                }
            }


            Browser.SwitchTo().Window(StartWindow);
            return Result;
        }

        [Test]
        public void TestMethod3()
        {
            Browser.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");

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

            int i;
            int j;

            int key1 = 0;
            int key2 = 0;

            int alfavit1;
            int alfavit2;

            string n;
            string m;


            List<IWebElement> Countries = Browser.FindElements(By.CssSelector("#content > form > table > tbody > tr.row")).ToList();
              string[] dd = new string[Countries.Count];
              for (i = 0; i < Countries.Count; i++)
              {
                IWebElement num1 = Browser.FindElements(By.CssSelector("#content > form > table > tbody > tr.row"))[i];
                IWebElement lll = num1.FindElement(By.CssSelector("td:nth-child(5) > a"));
                IWebElement mmm = num1.FindElement(By.CssSelector("td:nth-child(6)"));
                n = mmm.GetAttribute("textContent");          
                if (n != "0")
                {                   
                    openInNewWindow((lll.GetAttribute("href")));

                   // String countr = FindWindow((lll.GetAttribute("href")));
                   // Browser.SwitchTo().Window(countr);


                    Browser.SwitchTo().Window(Browser.WindowHandles[1]);
                    List<IWebElement> Zones = Browser.FindElements(By.CssSelector("#table-zones > tbody > tr:not(.header)")).ToList();
                    string[] nn = new string[(Zones.Count)-1];
                    for (j = 0; j < (Zones.Count)-1; j++)
                    {
                        IWebElement num2 = Browser.FindElements(By.CssSelector("#table-zones > tbody > tr:not(.header)"))[j];
                        IWebElement sss = num2.FindElement(By.CssSelector("td:nth-child(3)"));
                        m = sss.GetAttribute("textContent");

                        nn[j] = sss.GetAttribute("textContent");
                        key2++;
                        if (key2 > 1)
                        {
                            alfavit2 = String.Compare(nn[j - 1], nn[j]);

                            if (alfavit2 > 0)
                            {
                                throw new ArgumentException("Страны не по алфавиту");
                            }
                        }

                    }

                    key2 = 0;
                   
                    Browser.Close();
                }               
                            
                Browser.SwitchTo().Window(Browser.WindowHandles[0]);

                dd[i] = lll.GetAttribute("textContent");
                key1++;
                if (key1 > 1)
                {
                    alfavit1 = String.Compare(dd[i-1], dd[i]);

                    if (alfavit1 > 0)
                    {
                        throw new ArgumentException("Страны не по алфавиту");
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
