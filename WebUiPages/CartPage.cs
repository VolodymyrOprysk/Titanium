using OpenQA.Selenium;
using System;
using Titanium.Decorators.Driver;
using Titanium.Decorators.Elements;

namespace WebUiPages
{
    public class CartPage
    {
        private readonly Driver driver;

        public CartPage(Driver driver)
        {
            this.driver = driver;
        }

        private Element CouponCodeTextField => driver.FindElement(By.Id("coupon_code"));
        private Element ApplyCouponButton => driver.FindElement(By.CssSelector("[value='Apply coupon']"));
        private Element QuantityBox => driver.FindElement(By.CssSelector(".input-text.qty.text"));
        private Element UpdateCart => driver.FindElement(By.CssSelector("[value='Update cart']"));
        private Element TotalPrice => driver.FindElement(By.CssSelector(".woocommerce-Price-amount.amount"));

        public void ApplyCoupon(string coupon)
        {
            CouponCodeTextField.TypeText(coupon);
            ApplyCouponButton.Click();
            driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(string newQuantity)
        {
            QuantityBox.TypeText(newQuantity);
            UpdateCart.Click();
            driver.WaitForAjax();
        }

        public string GetTotalPrice() => TotalPrice.Text;
    }
}
