using System;
using System.Collections.Generic;
using System.Data.OleDb;
namespace Production_Code
{
    public class Product:IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public decimal Price
        {
            get { return GetPriceFromDatabase(); }
            set { throw new NotImplementedException(); }
        }

        public string GetProductCategory()
        {
            throw new NotImplementedException();
        }

        private decimal GetPriceFromDatabase()
        {
            #region Retrieve Price from DB

            //var conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"I:\\Unit Testing ITI 2019\\Smart\\sample.mdb\"");
            //var query = "select Price from Product where ID =" + ID;
            //var cmd = new OleDbCommand(query, conn);
            //conn.Open();
            //var price = (decimal)cmd.ExecuteScalar();
            //conn.Close();
            return 54.97978m;

            #endregion
        }
    }
}
