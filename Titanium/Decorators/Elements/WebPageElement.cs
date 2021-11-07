using OpenQA.Selenium;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;

namespace Titanium.Decorators.Elements
{
    public class WebPageElement : Element
    {
        private readonly IWebDriver webDriver;
        private readonly IWebElement webElement;
        private readonly By by;

        public WebPageElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            this.webDriver = webDriver;
            this.webElement = webElement;
            this.by = by;
        }

        public override By By => by;

        public override string Text => webElement?.Text;

        public override bool? Displayed => webElement?.Displayed;

        public override bool? Enabled => webElement?.Enabled;

        public override void Click()
        {
            WaitToBeClickable(By);
            webElement.Click();
        }

        public override string GetAttribute(string attributeName) => webElement?.GetAttribute(attributeName);   

        public override void TypeText(string text)
        {
            webElement?.Clear();
            webElement?.SendKeys(text);
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
