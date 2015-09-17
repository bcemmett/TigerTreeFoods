using System;
using System.Collections.Generic;

namespace LoyaltyProgramManagement.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public virtual Member Member { get; set; }
    }
}
