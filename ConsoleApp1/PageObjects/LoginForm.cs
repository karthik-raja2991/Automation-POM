using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.PageObjects
{
    public class LoginForm : BasePage
    {
        private By userNameTextBox = By.CssSelector("form[name='login'] li:nth-of-type(2) input");
        private By passwordTextBox = By.CssSelector("form[name='login'] li:nth-of-type(4) input");
        private By repeatPasswordTextBox = By.CssSelector("form[name='login'] li:nth-of-type(6) input");
        private By loginButton = By.CssSelector("form[name='login'] li:nth-of-type(7) input");

        public LoginForm(IWebDriver driver) :base(driver)
        {
        }

        // Methods
        public void EnterUserName(string userNameText)
        {
            SendText(userNameText, userNameTextBox);
        }

        public void EnterPassword(string password)
        {
            SendText(password, passwordTextBox);
        }

        public void EnterRepeatPassword(string repeatPassword)
        {
            SendText(repeatPassword, repeatPasswordTextBox);
        }

        public void ClickLoginButton()
        {
            WebElementClick(loginButton);
        }

        public string VerifySucessMessage()
        {
            return GetTextFromAlertPopUp();
        }

        public void CloseTheAlertPopUp()
        {
            AcceptOrCloseTheAlertPopUp();
        }
    }
}
