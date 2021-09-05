using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Threading;
using Titanium.Decorators.Driver;
using Titanium.Enums.BrowserEnum;

namespace WebUiTests
{
    [TestClass]
    public class SampleTests
    {
        private static Driver driver;
        private static Stopwatch stopWatch;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            stopWatch = Stopwatch.StartNew();
            driver = new DriverLogger(new WebDriver());
            driver.Start(Browser.Chrome);
            Debug.WriteLine($"Browser init ended in {stopWatch.Elapsed.TotalSeconds}");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Quit();
            Debug.WriteLine(stopWatch.Elapsed.TotalSeconds);
            stopWatch.Stop();
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            driver.GoToUrl("https://demos.bellatrix.solutions/");
            var addToCartFalcon9 = driver.FindElement(By.CssSelector("[data-product_id='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(3000);
            var viewCartButton = driver.FindElement(By.CssSelector(".added_to_cart.wc-forward"));
            viewCartButton.Click();

            ApplyCoupon();

            IncreaseProductQuantity();
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.TypeText("happybirthday");
            var applyCouponButton = driver.FindElement(By.CssSelector("[value='Apply coupon']"));
            applyCouponButton.Click();
            driver.WaitForAjax();
            var messageAlert = driver.FindElement(By.CssSelector(".woocommerce-message"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = driver.FindElement(By.CssSelector(".input-text.qty.text"));
            quantityBox.TypeText("2");
            driver.WaitForAjax();
            var updateCart = driver.FindElement(By.CssSelector("[value='Update cart']"));
            updateCart.Click();
            driver.WaitForAjax();
            var totalSpan = driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00ˆ", totalSpan.Text);
        }
    }
}
