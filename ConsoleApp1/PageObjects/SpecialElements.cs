using OpenQA.Selenium;

namespace ConsoleApp1.PageObjects
{
    public class SpecialElements
    {
        private readonly IWebDriver _driver;
        public SpecialElements(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
