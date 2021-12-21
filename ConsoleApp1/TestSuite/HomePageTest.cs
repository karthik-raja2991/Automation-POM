using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TestSuite
{
    public class HomePageTest
    {
        [SetUp]
        public void SetUp()
        {
            BaseApplication.StartUp();
        }

        [Test]
        public void TC_001_VerifyTitleIsPresent()
        {
            NavigationWorkFlows navigationWorkFlows = new NavigationWorkFlows();
            HomePage homePage = navigationWorkFlows.NavigateToHomePage();

            Assert.AreEqual(homePage.GetHeadLine(), "Introduction");
        }

        [Test]

        public void TC_002_VerifyIfImageIsPresent()
        {
            NavigationWorkFlows navigationWorkFlows = new NavigationWorkFlows();
            HomePage homePage = navigationWorkFlows.NavigateToHomePage();

            homePage.CheckIfImageIsLoadedAndVisible();
        }

        [TearDown]
        public void TearDown()
        {
            BaseApplication.EndTest();
        }
    }
}
