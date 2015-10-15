using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PosTerminal
{
    class DatabaseAccess
    {
        public ShoppingItem GetItemDetails(string barcode)
        {
            var shoppingItem = new ShoppingItem();
            string connectionString = ConfigurationManager.ConnectionStrings["LiveDb"].ConnectionString;
            
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = @"
                        SELECT TOP 1
                                ProductId ,
                                Barcode ,
                                RegularPrice ,
                                OfferPrice ,
                                TillDescription
                        FROM    dbo.Products
                        WHERE   Barcode = N'"
                        + barcode
                        + "'";
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        throw new Exception("Couldn't find barcode in the database");
                    }
                    while (reader.Read())
                    {
                        shoppingItem.ProductId = (int) reader["ProductId"];
                        shoppingItem.Barcode = (string) reader["Barcode"];
                        shoppingItem.RegularPrice = (Decimal) reader["RegularPrice"];
                        shoppingItem.OfferPrice = reader["OfferPrice"] == DBNull.Value ? null : (Decimal?) reader["OfferPrice"];
                        shoppingItem.TillDescription = (string) reader["TillDescription"];
                    }
                }
            }
            return shoppingItem;
        }
    }
}