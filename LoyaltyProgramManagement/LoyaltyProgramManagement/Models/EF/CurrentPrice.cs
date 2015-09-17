using System;
using System.Collections.Generic;

namespace LoyaltyProgramManagement.Models
{
    public partial class CurrentPrice
    {
        public CurrentPrice()
        {
            this.Members = new List<Member>();
        }

        public int ItemId { get; set; }
        public string Barcode { get; set; }
        public decimal RegularPrice { get; set; }
        public Nullable<decimal> OfferPrice { get; set; }
        public string TillDescription { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
