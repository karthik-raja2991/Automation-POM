using ConsoleApp1.PageObjects;
using NUnit.Framework;
using System.Threading;

namespace ConsoleApp1
{
    public class EntryPoint
    {
        static void Main()
        {
            /*
            Driver.driver.Navigate().GoToUrl("https://testing.todorvachev.com/");
            NavigationWorkFlows navWorkFlows = new NavigationWorkFlows();

            TestScenarios testScenarios = navWorkFlows.NavigateToTestScenarios();
            LoginForm loginForm = navWorkFlows.NavigateToLoginForm();

            loginForm.EnterUserName(Config.Credentials.Valid.userName);
            loginForm.EnterPassword(Config.Credentials.Valid.password);
            loginForm.EnterRepeatPassword(Config.Credentials.Valid.repeatPassword);
            loginForm.ClickLoginButton();

            Assert.AreEqual(loginForm.VerifySucessMessage(), "Succesful login!");
            Thread.Sleep(2000);

            Driver.driver.SwitchTo().Alert().Accept();

            Thread.Sleep(2000); */
            BaseApplication.driver.Navigate().GoToUrl("https://testing.todorvachev.com/");
            NavigationWorkFlows navigationWorkFlows = new NavigationWorkFlows();
            navigationWorkFlows.NavigateToTestScenarios();
            TestScenariosWorkFlows testScenariosWorkFlows = new TestScenariosWorkFlows();
            testScenariosWorkFlows.RegisterAndLoginToApplication();

        }
    }
}

