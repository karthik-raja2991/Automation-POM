using OpenQA.Selenium;

namespace ConsoleApp1.PageObjects
{
    public class Selectors
    {
        private readonly IWebDriver _driver;
        public Selectors(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
