using ConsoleApp1.BaseApp.Logs;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ConsoleApp1.BaseApp;

namespace ConsoleApp1.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected IWebElement FindElement(By locator)
        {
            IWebElement element=null;
            try
            {
                element = _driver.FindElement(locator);
            }
            catch (NoSuchElementException ex)
            {
                BaseApplication.logger.LogException(ex);
                
            }
            return element;
        }

        protected void SendText(string text, By locator, bool clearText = true)
        {
            if (clearText)
            {
                FindElement(locator).Clear();
            }
            FindElement(locator).SendKeys(text);
            BaseApplication.logger.LogMessage("The text" + text + "was entered in " + GetText(locator));
        }

        protected void WebElementClick(By locator)
        {
            if (IsElementDisplayed(locator))
            {
                FindElement(locator).Click();
                BaseApplication.logger.LogMessage("Sucessfully clicked the webelement" + GetText(locator));
            }
        }

        protected bool IsElementDisplayed(By locator)
        {
            bool status = false;
            try
            {
                status = FindElement(locator).Displayed;
                BaseApplication.logger.LogMessage("The element " + FindElement(locator).Text + " is displayed");
            }
            catch (NoSuchElementException ex)
            {
                BaseApplication.logger.LogException(ex);
            }
            catch (Exception ex)
            {
                BaseApplication.logger.LogException(ex);
            }
          return status;
        }

        protected void SelectElement(By locator, string text, string option = "value")
        {
            try
            {
                SelectElement select = new SelectElement(FindElement(locator));
                switch (option)
                {
                    case "value":
                        select.SelectByValue(text);
                        BaseApplication.logger.LogMessage("Sucessfully selected the" + text + " from" + FindElement(locator).Text + "dropdown");
                        break;
                    case "index":
                        select.SelectByIndex(int.Parse(text));
                        BaseApplication.logger.LogMessage("Sucessfully selected the" + text + " from" + locator + "dropdown");
                        break;
                    case "text":
                        select.SelectByText(text);
                        BaseApplication.logger.LogMessage("Sucessfully selected the" + text + " from" + locator + "dropdown");
                        break;
                }
            }
            catch (Exception ex)
            {
                BaseApplication.logger.LogException(ex);
            }
        }

        protected string GetText(By locator)
        {
            return FindElement(locator).Text;
        }

        protected bool CheckIfImageIsPresent(By locator)
        {
            bool status = false;
            status = (bool)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].complete"
                + "&& typeof arguments[0].naturalWidth!=\"undefined\""
                + "&& arguments[0].naturalWidth >0", FindElement(locator));
            return status;
        }

        protected string GetTextFromAlertPopUp()
        {
            try
            {
                return _driver.SwitchTo().Alert().Text;
            }
            catch(Exception ex)
            {
                BaseApplication.logger.LogException(ex);
                return string.Empty;
            }
        }

        protected void AcceptOrCloseTheAlertPopUp(string option = "Accept")
        {
            switch (option)
            {
                case "Close":
                    try
                    {
                        _driver.SwitchTo().Alert().Dismiss();
                    }
                    catch (Exception ex)
                    {
                        BaseApplication.logger.LogException(ex);
                    }
                    
                    break;
                case "Accept":
                    try
                    {
                        _driver.SwitchTo().Alert().Accept();
                    }
                    catch (Exception ex)
                    {
                        BaseApplication.logger.LogException(ex);
                    }
                    
                    break;
            }

        }

        protected void SelectTheRadioButton(By locator)
        {
            if (!VerifyIfElementIsSelected(locator))
            {
                FindElement(locator).Click();
                BaseApplication.logger.LogMessage("Sucessfully clicked the radio button");
            }
        }

        protected bool VerifyIfElementIsSelected(By locator)
        {
            try
            {
                return FindElement(locator).Selected;
            }
            catch(ElementNotSelectableException ex)
            {
                BaseApplication.logger.LogException(ex);
                return false;
            }
        }

        protected void CheckOrUncheckTheCheckBox(By locator, bool wantToBeChecked = true)
        {
            if (wantToBeChecked)
            {
                if (!VerifyIfElementIsSelected(locator))
                {
                    try
                    {
                        FindElement(locator).Click();
                    }
                    catch (Exception ex)
                    {
                        BaseApplication.logger.LogException(ex);
                    }
                }
            }
            else
            {
                if (VerifyIfElementIsSelected(locator))
                {
                    try
                    {
                        FindElement(locator).Click();
                    }
                    catch (Exception ex)
                    {
                        BaseApplication.logger.LogException(ex);
                    }
                   
                }
            }
        }

    }
}
