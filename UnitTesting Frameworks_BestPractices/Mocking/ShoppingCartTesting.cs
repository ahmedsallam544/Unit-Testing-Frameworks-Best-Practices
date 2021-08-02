//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Production_Code;
using System; 

namespace UnitTesting_Frameworks_BestPractices.Mocking
{
    public class ShoppingCartTesting
    {
        [Fact]
        public void AddProduct_AddingProductWithPrice100_ShouldMakeTotal100_1()
        {
            // Arrange
            var cart = new ShoppingCart();
            //make sure product with ID =1 in database has Price = 100.00
            var product = new Product { ID = 1, Name = "Product1" };

            // Act
            cart.AddProduct(product);
           
            // Assert
            Assert.Equal<decimal>(54.97978M, cart.Total);
        }
    }
}
