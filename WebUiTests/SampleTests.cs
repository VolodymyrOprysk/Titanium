using Microsoft.VisualStudio.TestTools.UnitTesting;
using Titanium.Attributes;
using Titanium.Enums.BrowserBehaviorEnum;
using Titanium.Enums.BrowserEnum;
using WebUiPages;

namespace WebUiTests
{
    [TestClass]
    public class SampleTests : BaseTest
    {
        private MainPage MainPage;
        private CartPage CartPage;
        public override void TestInit()
        {
            MainPage = new MainPage(Driver);
            CartPage = new CartPage(Driver);
        }

        [TestMethod]
        [ExecutionBrowser(Browser.Chrome, BrowserBehavior.RestartEveryTime)]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            MainPage.AddRocketToShoppingCart();
            CartPage.ApplyCoupon("happybirthday");
            Assert.AreEqual("50.00ˆ", CartPage.GetTotalPrice(), "Total price does NOT match");
        }
    }
}
