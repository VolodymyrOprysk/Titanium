using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Threading;
using Titanium.Attributes;
using Titanium.Decorators.Driver;
using Titanium.Enums.BrowserBehaviorEnum;
using Titanium.Enums.BrowserEnum;

namespace WebUiTests
{
    [TestClass]
    public class SampleTests : BaseTest
    {

        [TestMethod]
        [ExecutionBrowser(Browser.Chrome, BrowserBehavior.RestartEveryTime)]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            AddRocketToShoppingCart();
            ApplyCoupon();
            IncreaseProductQuantity();
        }

        private void AddRocketToShoppingCart()
        {
            Driver.GoToUrl("https://demos.bellatrix.solutions/");
            var addToCartFalcon9 = Driver.FindElement(By.CssSelector("[data-product_id='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(3000);
            var viewCartButton = Driver.FindElement(By.CssSelector(".added_to_cart.wc-forward"));
            viewCartButton.Click();
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = Driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.TypeText("happybirthday");
            var applyCouponButton = Driver.FindElement(By.CssSelector("[value='Apply coupon']"));
            applyCouponButton.Click();
            Driver.WaitForAjax();
            var messageAlert = Driver.FindElement(By.CssSelector(".woocommerce-message"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = Driver.FindElement(By.CssSelector(".input-text.qty.text"));
            quantityBox.TypeText("2");
            Driver.WaitForAjax();
            var updateCart = Driver.FindElement(By.CssSelector("[value='Update cart']"));
            updateCart.Click();
            Driver.WaitForAjax();
            var totalSpan = Driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00ˆ", totalSpan.Text);
        }
    }
}
