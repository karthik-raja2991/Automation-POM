using OpenQA.Selenium;

namespace ConsoleApp1.PageObjects
{
    public class RightSideBar
    {
        private readonly IWebDriver _driver;
        public RightSideBar(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
