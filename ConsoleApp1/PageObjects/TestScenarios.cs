using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.PageObjects
{
    public class TestScenarios : BasePage
    {
        public TestScenarios(IWebDriver driver) : base(driver)
        {
        }

        private By loginForm = By.CssSelector("div#main-content article:nth-of-type(1) h3 a");
        private By registerForm = By.CssSelector("div#main-content article:nth-of-type(2) h3 a");

        public void ClickLoginFormLink()
        {
            WebElementClick(loginForm);
        }

        public void ClickRegisterFormLink()
        {
            WebElementClick(registerForm);
        }
    }
}
