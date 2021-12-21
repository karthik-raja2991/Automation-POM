using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ConsoleApp1.PageObjects
{
    public class Menu : BasePage
    {
        public Menu(IWebDriver driver) : base(driver)
        {
        }

        private By introductionMenuOption = By.Id("menu-item-25");
        private By SelectorsMenuOption = By.Id("menu-item-106");
        private By SpecialElementsMenuOption = By.Id("menu-item-35");
        private By testCaseMenuOption = By.Id("menu-item-57");
        private By testScenariosMenuOption = By.Id("menu-item-58");
        private By aboutMenuOption = By.Id("menu-item-26");
        //private By aboutMenuOption = By.Id("menu-item-10000000000");

        public void ClickOnSelectors()
        {
            WebElementClick(SelectorsMenuOption);
        }

        public void ClickOnSpecialElements()
        {
            WebElementClick(SpecialElementsMenuOption);
        }

        public void ClickOnTestCases()
        {
            WebElementClick(testCaseMenuOption);
        }

        public void ClickOnTestScenarios()
        {
            WebElementClick(testScenariosMenuOption);
        }

        public void ClickOnAboutMenu()
        {
            WebElementClick(aboutMenuOption);
        }

        public void ClickOnIntroductions()
        {
            WebElementClick(introductionMenuOption);
        }

        public bool VerifyIfAllLinksArePresent()
        {
            return (IsElementDisplayed(introductionMenuOption) && IsElementDisplayed(SelectorsMenuOption) && IsElementDisplayed(SpecialElementsMenuOption) && IsElementDisplayed(testCaseMenuOption) && IsElementDisplayed(testScenariosMenuOption) && IsElementDisplayed(aboutMenuOption));
        }
    }
}
