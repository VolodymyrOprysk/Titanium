using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Titanium.Decorators.Elements;
using Titanium.Enums.BrowserEnum;

namespace Titanium.Decorators.Driver
{
    public class LoggingDriver : DriverDecorator
    {
        public LoggingDriver(Driver driver) : base(driver) 
        {

        }

        public override IWebDriver GetWebDriver()
        {
            Console.WriteLine("Native Selenium IWebDriver accessed");
            return Driver?.GetWebDriver();
        }

        public override void Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            Driver?.Start(browser);
        }

        public override void GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            Driver?.GoToUrl(url);
        }

        public override void Quit()
        {
            Console.WriteLine("Quit browser");
            Driver?.Quit();
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine($"Find Element by locator = {locator}");
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            Console.WriteLine($"Find Elements by locator = {locator}");
            return Driver?.FindElements(locator);
        }

        public override void WaitForAjax()
        {
            Console.WriteLine("Wait for AJAX");
            Driver?.WaitForAjax();
        }

        public override void DeleteAllCookies()
        {
            Console.WriteLine("Cookies deleting");
            Driver?.DeleteAllCookies();
        }
    }
}
