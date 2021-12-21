namespace ConsoleApp1
{
    public class NavigationWorkFlows
    {
        public PageObjects.Menu menu;
        public NavigationWorkFlows()
        {
            menu = new PageObjects.Menu(BaseApplication.driver);
        }

        public PageObjects.Selectors NavigateToSelectorsTab()
        {
            menu.ClickOnSelectors();
            return new PageObjects.Selectors(BaseApplication.driver);
        }

        public PageObjects.SpecialElements NavigateToSpecialElements()
        {
            menu.ClickOnSpecialElements();
            return new PageObjects.SpecialElements(BaseApplication.driver);
        }

        public PageObjects.TestCases NavigateToTestCases()
        {
            menu.ClickOnTestScenarios();
            return new PageObjects.TestCases(BaseApplication.driver);
        }

        public PageObjects.TestScenarios NavigateToTestScenarios()
        {
            menu.ClickOnTestScenarios();
            return new PageObjects.TestScenarios(BaseApplication.driver);
        }

        public PageObjects.LoginForm NavigateToLoginForm()
        {
            PageObjects.TestScenarios testScenarios = NavigateToTestScenarios();
            testScenarios.ClickLoginFormLink();
            return new PageObjects.LoginForm(BaseApplication.driver);
        }

        public HomePage NavigateToHomePage()
        {
            menu.ClickOnIntroductions();
            return new HomePage(BaseApplication.driver);
        }
    }
}
