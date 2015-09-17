using System;
using System.Collections.Generic;

namespace LoyaltyProgramManagement.Models
{
    public partial class Member
    {
        public Member()
        {
            this.Transactions = new List<Transaction>();
        }

        public int MemberId { get; set; }
        public string MembershipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public int FavouriteProduct { get; set; }
        public virtual CurrentPrice CurrentPrice { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
