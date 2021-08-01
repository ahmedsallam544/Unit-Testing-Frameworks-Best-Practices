//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Moq;
using Production_Code;
using System; 

namespace UnitTesting_Frameworks_BestPractices
{ 
    public class ShoppingCartTestingUsingMoq
    {
        [Fact]
        public void AddProduct_MOQ_AddingProductWithPrice100_ShouldMakeTotal100()
        {
            // Arrange
            var mock = new Mock<IProduct>();
            mock.SetupGet(m => m.Price).Returns(100.00M);
            var cart = new ShoppingCart();
            
            // Act
            cart.AddProduct(mock.Object);

            // Assert
            Assert.Equal(100.00M, cart.Total);

        }
    }
}

