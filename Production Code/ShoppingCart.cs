using System;
using System.Collections.Generic;
using System.Text;

namespace Production_Code
{
   public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public decimal Total { get; set; }

        public void AddProduct(IProduct product)
        {
            Total = Total + product.Price;
        }

    }
}
