using NUnit.Framework;

namespace ConsoleApp1.TestSuite
{
    public class MenuTest
    {
        [SetUp]
        public void SetUp()
        {
            BaseApplication.StartUp();
        }

        [Test]
        public void ValidateMenuArePresent()
        {
            TestScenariosWorkFlows testScenariosWorkFlows = new TestScenariosWorkFlows();
            Assert.IsTrue(testScenariosWorkFlows.VerifyMenuTab());
        }

        [TearDown]
        public void TearDown()
        {
            BaseApplication.EndTest();
        }
    }
}
