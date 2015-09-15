using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PosLoadGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Task.Run(() => Console.WriteLine("Looked up {0}",MakeDatabaseRequest()));
            }
        }

        static string MakeDatabaseRequest()
        {
            string barcode = GenerateRandomBarcode();
            string connectionString = ConfigurationManager.ConnectionStrings["LiveDb"].ConnectionString;
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
                        WHERE   Barcode = @barcode";
                    cmd.Parameters.AddWithValue("barcode", barcode);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                }
            }
            return barcode;
        }

        private static string GenerateRandomBarcode()
        {
            var chars = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 16)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}