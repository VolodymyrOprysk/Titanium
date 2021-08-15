using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebUiTests
{
    [TestClass]
    public class SampleTests
    {
        private static IWebDriver driver;
        private static string purchaseEmail;
        private static string purchaseOrderNumber;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            driver.Navigate().GoToUrl("https://demos.bellatrix.solutions/");
            var addToCartFalcon9 = driver.FindElement(By.CssSelector("[data-product_id='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(3000);
            var viewCartButton = driver.FindElement(By.CssSelector(".added_to_cart.wc-forward"));
            viewCartButton.Click();
            var couponCodeTextField = driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");
            var applyCouponButton = driver.FindElement(By.CssSelector("[value='Apply coupon']"));
            applyCouponButton.Click();
            Thread.Sleep(3000);
            var messageAlert = driver.FindElement(By.CssSelector(".woocommerce-message"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
            var quantityBox = driver.FindElement(By.CssSelector(".input-text.qty.text"));
            quantityBox.Clear();
            Thread.Sleep(1000);
            quantityBox.SendKeys("2");
            Thread.Sleep(3000);
            var updateCart = driver.FindElement(By.CssSelector("[value='Update cart']"));
            updateCart.Click();
            Thread.Sleep(3000);
            var totalSpan = driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00�", totalSpan.Text);
        }
    }
}