using System;
using System.Data.SqlClient;

namespace PosTerminal
{
    class DatabaseAccess
    {
        public ShoppingItem GetItemDetails(string barcode)
        {
            var shoppingItem = new ShoppingItem();
            string connectionString = "Data Source=.\\sql2014;Initial Catalog=TigerTreeFoods;Integrated Security=True;";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
                        SELECT TOP 1
                                ItemId ,
                                Barcode ,
                                RegularPrice ,
                                OfferPrice ,
                                TillDescription
                        FROM    dbo.CurrentPrices
                        WHERE   Barcode = '"
                        + barcode
                        + "'";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        shoppingItem.ItemId = (int) reader["ItemId"];
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