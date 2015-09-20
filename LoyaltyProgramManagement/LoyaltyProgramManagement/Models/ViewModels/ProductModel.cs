using System;

namespace LoyaltyProgramManagement.Models.ViewModels
{
    public class ProductModel
    {
        public string TillDescription { get; set; }
        public string Barcode { get; set; }
        public Decimal RegularPrice { get; set; }
        public Decimal? OfferPrice { get; set; }
        public int ProductId { get; set; }
    }
}