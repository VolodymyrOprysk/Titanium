using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using Titanium.Decorators.Elements;
using Titanium.Enums.BrowserEnum;
using System.Collections.Generic;

namespace Titanium.Decorators.Driver
{
    public class WebDriver : Driver
    {
        private IWebDriver webDriver;
        private WebDriverWait webDriverWait;

        public override void Start(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    webDriver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Firefox:
                    webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Edge:
                    webDriver = new EdgeDriver(Environment.CurrentDirectory);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }

        public override Element FindElement(By locator)
        {
            var nativeWebElement = webDriverWait.Until(ExpectedConditions.ElementExists(locator));
            var element = new WebPageElement(webDriver, nativeWebElement, locator);
            var loggedElement = new LoggingElement(element);

            return loggedElement;
        }

        public override List<Element> FindElements(By locator)
        {
            var nativeWebElements = webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            var elements = new List<Element>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                var element = new WebPageElement(webDriver, nativeWebElement, locator);
                elements.Add(element);
            }

            return elements;
        }

        public override void GoToUrl(string url)
        {
            webDriver
                .Navigate()
                .GoToUrl(url);
        }

        public override void Quit()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
            }
        }

        public override void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)webDriver;
            webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString().Equals("0"));
        }

        public override void DeleteAllCookies()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
