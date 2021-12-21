using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BaseApp
{
    public sealed class BrowserExtension
    {
        public static IWebDriver CreateBrowserAndNavigateToURL(BrowserType browserType)
        {
            IWebDriver driver = CheckExecutionLocationAndCreateBrowser(browserType);
            driver.Navigate().GoToUrl(Config.BaseURL);
            driver.Manage().Window.Maximize();
            WaitForPageToLoad(driver);
            return driver;
        }

        private static void WaitForPageToLoad(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            IJavaScriptExecutor javaScriptExecutor = driver as IJavaScriptExecutor;

            wait.Until((d) =>
            {
                try
                {
                    string readystate = javaScriptExecutor.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                    if (readystate.ToLower().Equals("complete"))
                    {
                        return true;
                    }
                    throw new Exception("Unable to load the page");
                }
                catch (InvalidOperationException ex)
                {
                    return ex.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException ex)
                {
                    return ex.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} exception caught", e);
                    return false;
                }
            });
        }

        private static IWebDriver CheckExecutionLocationAndCreateBrowser(BrowserType browserType)
        {
            IWebDriver seleniumWebDriver = null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    seleniumWebDriver = new ChromeDriver();
                    break;
                case BrowserType.FireFox:
                    seleniumWebDriver = new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                     seleniumWebDriver = new EdgeDriver();
                    break;
                default:
                    throw new InvalidDataException();
            }

            return seleniumWebDriver;
        }
    }
}
