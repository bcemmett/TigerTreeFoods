using System;
using System.Collections.Generic;
using LoyaltyProgramManagement.Models.ViewModels;

namespace LoyaltyProgramManagement.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Members = new List<Member>();
        }

        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public decimal RegularPrice { get; set; }
        public Nullable<decimal> OfferPrice { get; set; }
        public string TillDescription { get; set; }
        public byte[] Image { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Member> Members { get; set; }

        public ProductModel ToProductModel()
        {
            return new ProductModel
            {
                ProductId = ProductId,
                Barcode = Barcode,
                Category = Category,
                RegularPrice = RegularPrice,
                OfferPrice = OfferPrice,
                TillDescription = TillDescription
            };
        }
    }
}
