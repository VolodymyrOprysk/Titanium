using OpenQA.Selenium;
using System.Collections.Generic;
using Titanium.Decorators.Elements;
using Titanium.Enums.BrowserEnum;

namespace Titanium.Decorators.Driver
{
    public abstract class DriverDecorator : Driver
    {
        protected readonly Driver Driver;

        protected DriverDecorator(Driver driver)
        {
            Driver = driver;
        }

        public override void Start(Browser browser)
        {
            Driver?.Start(browser);
        }

        public override void Quit()
        {
            Driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            return Driver?.FindElements(locator);
        }
    }
}
