using OpenQA.Selenium;

namespace ConsoleApp1.PageObjects
{
    public class TestCases
    {
        private readonly IWebDriver _driver;
        public TestCases(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
