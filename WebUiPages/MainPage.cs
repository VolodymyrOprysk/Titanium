using OpenQA.Selenium;
using System;
using Titanium.Decorators.Driver;
using Titanium.Decorators.Elements;

namespace WebUiPages
{
    public class MainPage
    {
        private readonly Driver driver;
        private readonly string url = "https://demos.bellatrix.solutions/";

        public MainPage(Driver driver)
        {
            this.driver = driver;
        }

        private Element AddToCartFalcon9 => driver.FindElement(By.CssSelector("[data-product_id='28']"));
        private Element ViewCartButton => driver.FindElement(By.CssSelector(".added_to_cart.wc-forward"));

        public void AddRocketToShoppingCart()
        {
            driver.GoToUrl(url);
            AddToCartFalcon9.Click();
            ViewCartButton.Click();
        }
    }
}
