using ConsoleApp1.BaseApp;
using ConsoleApp1.BaseApp.Logs;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Linq;

namespace ConsoleApp1
{
    public static class BaseApplication
    {
        public static IWebDriver driver;
        public static Log logger;

        public static void StartUp()
        {
            driver = BrowserExtension.CreateBrowserAndNavigateToURL(SelectBrowserType(Config.BrowserDetails.browserType));
            logger = new Log();
        }

        public static void EndTest()
        {
            logger.EndTestReport();
            if (driver != null)
            {
                driver.Quit();
            }
        }
        private static BrowserType SelectBrowserType(string browserType)
        {
            var supportedBrowsers = browserType.Split(',');
            return supportedBrowsers.Select(x => (BrowserType)Enum.Parse(typeof(BrowserType), x)).Aggregate((current, next) => current | next);
        }

        public static void CaptureScreenShot()
        {
            try
            {
                ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(logger.loginfo.ScreenShotFileNAme, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                logger.LogMessage("Not able to capture screenshot");
            }
        }
    }
}
