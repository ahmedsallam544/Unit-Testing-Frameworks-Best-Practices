using Production_Code;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Frameworks_BestPractices.Mocking
{
    public class ProductMock : IProduct
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string GetProductCategory()
        {
            throw new NotImplementedException();
        }
    }
}
