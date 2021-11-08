using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Titanium;
using Titanium.Decorators.Driver;
using Titanium.Observer;

namespace WebUiTests
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject currentTestExecutionSubject;
        private static readonly LoggingDriver loggingDriver;
        private static readonly BrowserDriver driver;


        static BaseTest()
        {
            currentTestExecutionSubject = new MsTestExecutionSubject();
            driver = new BrowserDriver();
            loggingDriver = new LoggingDriver(driver);
            new BrowserLaunchTestBehaviorObserver(currentTestExecutionSubject, loggingDriver);
            var memberInfo = MethodBase.GetCurrentMethod();
            currentTestExecutionSubject.TestInstanciated(memberInfo);
        }

        public BaseTest()
        {
            Driver = loggingDriver;
        }

        public Driver Driver { get; set; }

        public TestContext TestContext { get; set; }

        public string TestName => TestContext.TestName;

        [ClassInitialize]
        public static void OnClassInitialize(TestContext testContext)
        {

        }

        [ClassCleanup]
        public static void OnClassCleanup()
        {

        }

        [TestInitialize]
        public void CoreTestInit()
        {
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            currentTestExecutionSubject.PreTestInit(TestContext, memberInfo);
            TestInit();
            currentTestExecutionSubject.PostTestInit(TestContext, memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            currentTestExecutionSubject.PreTestCleanUp(TestContext, memberInfo);
            TestCleanup();
            currentTestExecutionSubject.PostTestCleanUp(TestContext, memberInfo);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            loggingDriver?.Quit();
        }

        public virtual void TestInit()
        {

        }

        public virtual void TestCleanup()
        {
            ScreenshotMaker.SaveScreenshot(loggingDriver.GetWebDriver(), TestName);
        }
    }
}
