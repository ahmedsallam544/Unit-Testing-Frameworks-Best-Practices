//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Production_Code;
using System; 

namespace UnitTesting_Frameworks_BestPractices.Mocking
{
    public class ShoppingCartTestingUsingManualMocking
    {
        [Fact]
        public void AddProduct_ManualMocking_AddingProductWithPrice100_ShouldMakeTotal100()
        {
            var cart = new ShoppingCart();
            var productMock = new ProductMock() { Price = 100.00M };
            cart.AddProduct(productMock);
            Assert.Equal(100.00M, cart.Total);
        }
    }
}
