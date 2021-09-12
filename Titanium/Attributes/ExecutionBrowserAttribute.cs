using System;
using Titanium.Enums.BrowserBehaviorEnum;
using Titanium.Enums.BrowserEnum;

namespace Titanium.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ExecutionBrowserAttribute : Attribute
    {
        public BrowserConfiguration BrowserConfiguration { get; set; }

        public ExecutionBrowserAttribute(Browser browser, BrowserBehavior browserBehavior)
        {
            BrowserConfiguration = new BrowserConfiguration(browser, browserBehavior);
        }
    }

    public class BrowserConfiguration
    {
        public Browser Browser { get; set; }

        public BrowserBehavior BrowserBehavior { get; set; }

        public BrowserConfiguration()
        {

        }

        public BrowserConfiguration(Browser browser, BrowserBehavior browserBehavior)
        {
            Browser = browser;
            BrowserBehavior = browserBehavior;
        }
    }
}
