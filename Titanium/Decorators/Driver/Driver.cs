using OpenQA.Selenium;
using System.Collections.Generic;
using Titanium.Decorators.Elements;
using Titanium.Enums.BrowserEnum;

namespace Titanium.Decorators.Driver
{
    public abstract class Driver
    {
        public abstract void Start(Browser browser);

        public abstract void Quit();

        public abstract void GoToUrl(string url);

        public abstract Element FindElement(By locator);

        public abstract List<Element> FindElements(By locator);

        public abstract void DeleteAllCookies();

        public abstract void WaitForAjax();
    }
}
