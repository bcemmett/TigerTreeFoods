using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace CompetitorPricingService.Controllers
{
    public class ApiController : Controller
    {
        //
        // GET: /Api/
        public ActionResult GetPrice(string ourPrice, string description)
        {
            var random = new Random();
            float competitorSaving = (float)random.Next(850, 1200) / 1000;
            Decimal basePrice = Decimal.Parse(ourPrice, NumberStyles.Currency);
            Decimal competitorPrice = (Decimal)competitorSaving * basePrice;
            Thread.Sleep(random.Next(800, 2000));
            return Content(competitorPrice.ToString());
        }
	}
}