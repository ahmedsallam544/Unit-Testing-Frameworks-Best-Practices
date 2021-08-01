using System;
using System.Collections.Generic;
using System.Text;

namespace Production_Code
{
   public interface IProduct
    {
        string Name { get; set; }

        decimal Price { get; set; }

        string GetProductCategory();
    }
}
