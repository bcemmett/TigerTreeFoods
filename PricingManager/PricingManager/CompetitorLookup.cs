using System;
using System.Configuration;
using System.Net;
using System.Text;

namespace PricingManager
{
    class CompetitorLookup
    {
        public static Decimal? LookupCompetitorPrice(string description, Decimal? ourPrice)
        {
            using (var client = new WebClient())
            {
                string baseUrl = ConfigurationManager.AppSettings["CompetitorPriceApi"];
                string url = String.Format("{0}/GetPrice/?ourPrice={1}&description={2}", baseUrl, ourPrice, description);
                client.Encoding = Encoding.UTF8;
                string competitorPriceString = client.DownloadString(url);
                return Decimal.Parse(competitorPriceString);
            }
        }
    }
}