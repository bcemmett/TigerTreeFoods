using System;
using System.Collections.Generic;
using LoyaltyProgramManagement.Models.ViewModels;

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

        public MemberModel ToMemberModel()
        {
            return new MemberModel
            {
                MemberId = MemberId,
                MembershipCode = MembershipCode,
                FirstName = FirstName,
                LastName = LastName,
                Address1 = Address1,
                Address2 = Address2,
                PostCode = PostCode,
                City = City,
            };
        }
    }
}
