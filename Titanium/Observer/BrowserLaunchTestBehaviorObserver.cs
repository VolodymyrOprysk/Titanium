using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titanium.Attributes;
using Titanium.Decorators.Driver;
using Titanium.Enums.BrowserBehaviorEnum;

namespace Titanium.Observer
{
    public class BrowserLaunchTestBehaviorObserver : BaseTestBehaviorObserver
    {
        private readonly Driver driver;
        private BrowserConfiguration currentBrowserConfiguration;
        private BrowserConfiguration previousBrowserConfiguration;

        public BrowserLaunchTestBehaviorObserver(ITestExecutionSubject testExecutionSubject, Driver driver) : base(testExecutionSubject)
        {
            this.driver = driver;
        }

        public override void PreTestInit(TestContext testContext, MemberInfo memberInfo)
        {
            currentBrowserConfiguration = GetBrowserConfiguration(memberInfo);

            bool shouldRestartBrowser = ShouldRestartBrowser(currentBrowserConfiguration);

            if (shouldRestartBrowser)
            {
                RestartBrowser();
            }

            previousBrowserConfiguration = currentBrowserConfiguration;
        }

        public override void PostTestCleanUp(TestContext testContext, MemberInfo memberInfo)
        {
            if (currentBrowserConfiguration.BrowserBehavior == BrowserBehavior.RestartOnFail
                && testContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
            {
                RestartBrowser();
            }
        }

        private void RestartBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
            }

            driver.Start(currentBrowserConfiguration.Browser);
        }

        private bool ShouldRestartBrowser(BrowserConfiguration browserConfiguration)
        {
            if (previousBrowserConfiguration == null)
            {
                return true;
            }

            bool shouldRestartBrowser = browserConfiguration.BrowserBehavior == BrowserBehavior.RestartEveryTime
                || browserConfiguration.BrowserBehavior == BrowserBehavior.NotSet;
            
            return shouldRestartBrowser;
        }

        private BrowserConfiguration GetBrowserConfiguration(MemberInfo memberInfo)
        {
            var result = new BrowserConfiguration();
            var methodBrowserType = GetExecutionBrowserMethodLevel(memberInfo);
            var classBrowserType = GetExecutionBrowserClassLevel(memberInfo.DeclaringType);
            if (methodBrowserType != null)
            {
                result = methodBrowserType;
            }
            else if (classBrowserType != null)
            {
                result = classBrowserType;
            }

            return result;
        }

        private BrowserConfiguration GetExecutionBrowserMethodLevel(MemberInfo memberInfo)
        {
            var executionBrowserAttribute = memberInfo.GetCustomAttribute<ExecutionBrowserAttribute>(true);
            if (executionBrowserAttribute != null)
            {
                return executionBrowserAttribute.BrowserConfiguration;
            }

            return null;
        }

        private BrowserConfiguration GetExecutionBrowserClassLevel(Type type)
        {
            var executionBrowserAttribute = type.GetCustomAttribute<ExecutionBrowserAttribute>(true);
            if (executionBrowserAttribute != null)
            {
                return executionBrowserAttribute.BrowserConfiguration;
            }

            return null;
        }
    }
}
