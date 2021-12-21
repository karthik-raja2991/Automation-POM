using NUnit.Framework;

namespace ConsoleApp1.TestSuite
{
    public class RegisterClass
    {
        [SetUp]
        public void SetUp()
        {
            BaseApplication.StartUp();
        }

        [Test]
        public void VerifyUserAbleToRegister()
        {
            NavigationWorkFlows navigationWorkFlows = new NavigationWorkFlows();
            PageObjects.TestScenarios testScenarios = navigationWorkFlows.NavigateToTestScenarios();
            testScenarios.ClickRegisterFormLink();
            TestScenariosWorkFlows testScenariosWorkFlows = new TestScenariosWorkFlows();
            testScenariosWorkFlows.RegisterNewUser();
        }

        [Test]
        public void VerifyErrorMessageForBlankFields()
        {
            NavigationWorkFlows navigationWorkFlows = new NavigationWorkFlows();
            PageObjects.TestScenarios testScenarios = navigationWorkFlows.NavigateToTestScenarios();
            testScenarios.ClickRegisterFormLink();
            PageObjects.Register register = new PageObjects.Register(BaseApplication.driver);

            // Click on Register button without entering any values
            register.ClickOnRegisterButton();

            // Validate error message
            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "User Id should not be empty / length be between 5 to 12");
            register.CloseThePopUp();

            // click on Register button without entering the password
            register.EnterUserName(Config.Credentials.Valid.userName);
            register.ClickOnRegisterButton();

            // validate the error message
            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "Password should not be empty / length be between 7 to 12");
            register.CloseThePopUp();

            //// click on Register button without entering the name
            register.EnterPassword(Config.Credentials.Valid.password);
            register.ClickOnRegisterButton();

            // validate the error message
            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "Username must have alphabet characters only");
            register.CloseThePopUp();

            // Click on register button without entering address
            register.SendName(Config.Credentials.Valid.name);
            register.ClickOnRegisterButton();

            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "User address must have alphanumeric characters only");
            register.CloseThePopUp();

            // click on register button without selectinr country
            register.SendAddress(Config.Credentials.Valid.address);
            register.ClickOnRegisterButton();

            // validate the error message
            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "Select your country from the list");
            register.CloseThePopUp();

            // click on register button without entering zip code
            register.SelectCountryFromDropDown(Config.Credentials.Valid.country);
            register.ClickOnRegisterButton();

            // assert the error messaghe
            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "ZIP code must have numeric characters only");
            register.CloseThePopUp();

            // click on register button without entering email address
            register.EnterZipCode(Config.Credentials.Valid.zipCode);
            register.ClickOnRegisterButton();

            // assert the error message
            Assert.AreEqual(register.GetMessageFromAlertPopUp(), "You have entered an invalid email address!");
            register.CloseThePopUp();
        }

        [TearDown]
        public void TearDown()
        {
            BaseApplication.EndTest();
        }
    }
}
