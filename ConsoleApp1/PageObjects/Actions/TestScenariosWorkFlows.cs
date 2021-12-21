using NUnit.Framework;

namespace ConsoleApp1
{
    public class TestScenariosWorkFlows
    {
        public void RegisterNewUser()
        {
            PageObjects.Register register = new PageObjects.Register(BaseApplication.driver);
            register.EnterUserName(Config.Credentials.Valid.userName);
            register.EnterPassword(Config.Credentials.Valid.password);
            register.SendName(Config.Credentials.Valid.name);
            register.SendAddress(Config.Credentials.Valid.address);
            register.SelectCountryFromDropDown(Config.Credentials.Valid.country);
            register.EnterZipCode(Config.Credentials.Valid.zipCode);
            register.EnterEmail(Config.Credentials.Valid.email);
            register.SelectSex(Config.Credentials.Valid.Sex);
            register.SelectLanguage();
            register.EnterAboutNotes(Config.Credentials.Valid.About);
            register.ClickOnRegisterButton();
        }

        public void LoginIntoFormAndVerify()
        {
            PageObjects.LoginForm loginForm = new PageObjects.LoginForm(BaseApplication.driver);
            loginForm.EnterUserName(Config.Credentials.Valid.userName);
            loginForm.EnterPassword(Config.Credentials.Valid.password);
            loginForm.EnterRepeatPassword(Config.Credentials.Valid.repeatPassword);
            loginForm.ClickLoginButton();
            Assert.AreEqual(loginForm.VerifySucessMessage(), "Succesful login!");
        }

        public void RegisterAndLoginToApplication()
        {
            PageObjects.TestScenarios testScenario = new PageObjects.TestScenarios(BaseApplication.driver);
            testScenario.ClickRegisterFormLink();
            RegisterNewUser();
            NavigationWorkFlows navWorkFlows = new NavigationWorkFlows();
            navWorkFlows.NavigateToLoginForm();
            LoginIntoFormAndVerify();
        }

        public bool VerifyMenuTab()
        {
            PageObjects.Menu menu = new PageObjects.Menu(BaseApplication.driver);

            return menu.VerifyIfAllLinksArePresent();
        }
    }
}
