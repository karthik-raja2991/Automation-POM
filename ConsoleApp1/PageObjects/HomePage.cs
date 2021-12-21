using ConsoleApp1.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1
{
    public class HomePage : BasePage
    {
        private By headLineHeader = By.CssSelector("div#main-content header>h1");
        private By toolImage = By.CssSelector("article#page-17 img");
        public HomePage(IWebDriver driver):base(driver)
        {
        }

        public string GetHeadLine()
        {
            return GetText(headLineHeader);
        }

        public bool CheckIfImageIsLoadedAndVisible()
        {
            return CheckIfImageIsPresent(toolImage);
        }
    }
}
