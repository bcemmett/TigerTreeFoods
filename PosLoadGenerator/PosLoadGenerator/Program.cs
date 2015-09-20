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
        private static Random m_rdm = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                var random = new Random();
                int delay = random.Next(50, 250);
                Thread.Sleep(delay);
                Task.Run(() => Console.WriteLine("Looked up {0}",MakeDatabaseRequest()));
            }
        }

        private static string MakeDatabaseRequest()
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
                                ProductId ,
                                Barcode ,
                                RegularPrice ,
                                OfferPrice ,
                                TillDescription
                        FROM    dbo.Products
                        WHERE   Barcode = @barcode";
                    cmd.Parameters.AddWithValue("barcode", barcode);
                    cmd.CommandTimeout = 300;
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
            var result = new string(
                Enumerable.Repeat(chars, 16)
                          .Select(s => s[m_rdm.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}