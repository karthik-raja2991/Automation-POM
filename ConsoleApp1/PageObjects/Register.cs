using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.PageObjects
{
    public class Register : BasePage
    {
        public Register(IWebDriver driver) : base(driver)
        {
        }

        private By userIdTextField = By.CssSelector("form[name='registration'] li>input[name='userid']");
        private By passwordTextBox = By.CssSelector("form[name='registration'] li>input[name='passid']");
        private By userNameTextBox = By.CssSelector("form[name='registration'] li>input[name='username']");
        private By addressTextBox = By.CssSelector("form[name='registration'] li>input[name='address']");
        private By countryDropDown = By.CssSelector("form[name='registration'] li>select[name='country']");
        private By zipCodeTextBox = By.CssSelector("form[name='registration'] li>input[name='zip']");
        private By emailTextBox = By.CssSelector("form[name='registration'] li>input[name='email']");
        private By maleSexRadioButton = By.CssSelector("form[name='registration'] li>input[value = 'Male']");
        private By knowEnglishCheckBox = By.CssSelector("form[name='registration'] li>input[name='languageQuestion']");
        private By aboutMeTextBox = By.CssSelector("form[name='registration'] li>textarea[name='desc']");
        private By registerButton = By.CssSelector("form[name='registration'] li>input[name='submit']");
        private By femaleSexRadioButton = By.CssSelector("form[name='registration'] li>input[value = 'Female']");

        public void EnterUserName(string userName)
        {
            SendText(userName, userIdTextField);
        }

        public void EnterPassword(string password)
        {
            SendText(password, passwordTextBox);
        }

        public void SendName(string name)
        {
            SendText(name, userNameTextBox);
        }

        public void SendAddress(string address)
        {
            SendText(address, addressTextBox);
        }

        public void SelectCountryFromDropDown(string optionValue, string selectBy = "value")
        {
            if (selectBy.Equals("value"))
            {
                switch (optionValue)
                {
                    case "USA":
                        optionValue = "AD";
                        break;
                    case "Russia":
                        optionValue = "AS";
                        break;
                    case "India":
                        optionValue = "DZ";
                        break;
                    case "Canada":
                        optionValue = "AL";
                        break;
                    case "Australia":
                        optionValue = "AF";
                        break;
                }
            }

           SelectElement(countryDropDown, optionValue);
        }

        public void EnterZipCode(string zipCode)
        {
            SendText(zipCode, zipCodeTextBox);
        }

        public void EnterEmail(string emailAddress)
        {
            SendText(emailAddress, emailTextBox);
        }

        public void SelectSex(string sex)
        {
            switch (sex)
            {
                case "Male":
                    SelectTheRadioButton(maleSexRadioButton);
                    break;
                case "Female":
                    SelectTheRadioButton(femaleSexRadioButton);
                    break;
            }           
        }

        public void SelectLanguage(bool wantEnglish = true)
        {
            if (wantEnglish)
            {
                CheckOrUncheckTheCheckBox(knowEnglishCheckBox);
            }
            else 
            {
                CheckOrUncheckTheCheckBox(knowEnglishCheckBox, wantEnglish);
            }
        }

        public void EnterAboutNotes(string description)
        {
            SendText(description, aboutMeTextBox);
        }

        public void ClickOnRegisterButton()
        {
            WebElementClick(registerButton);
        }

        public string GetMessageFromAlertPopUp()
        {
            return GetTextFromAlertPopUp();
        }

        public void CloseThePopUp()
        {
            AcceptOrCloseTheAlertPopUp();
        }
    }
}
