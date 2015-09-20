using System;
using System.Collections.Generic;
using System.Linq;
using LoyaltyProgramManagement.Models;

namespace LoyaltyProgramManagement
{
    public class TigerTreeDatabase
    {
        public List<Member> SearchMembers(int resultsToFetch, string firstName, string lastName, string city, string membershipCode, bool recentTransactions)
        {
            using (var db = new TigerTreeFoodsContext())
            {
                if (!String.IsNullOrWhiteSpace(membershipCode))
                {
                    IEnumerable<Member> membersByMembershipCode = db.Members.Where(m => m.MembershipCode == membershipCode);
                    return membersByMembershipCode.ToList();
                }

                IEnumerable<Member> members = db.Members
                    .Where(m => 
                        (m.FirstName == firstName || firstName == null || firstName == String.Empty)
                        && (m.LastName == lastName || lastName == null || lastName == String.Empty)
                        && (m.City == city || city == null || city == String.Empty)
                        && (m.MembershipCode == membershipCode || membershipCode == null || membershipCode == String.Empty)
                    );
                
                if (recentTransactions)
                {
                    DateTime oneWeekAgo = DateTime.UtcNow.AddDays(-7);
                    return members
                        .Where(m => m.Transactions
                            .Count(t => t.PurchaseDate > oneWeekAgo) > 0)
                        .ToList();
                }
                
                return members.Take(resultsToFetch).ToList();
            }
        }

        public List<Product> SearchProducts(string barcode, string description)
        {
            using (var db = new TigerTreeFoodsContext())
            {
                if (!String.IsNullOrWhiteSpace(barcode))
                {
                    return db.Products.Where(p => p.Barcode == barcode).ToList();
                }

                if (!String.IsNullOrWhiteSpace(description))
                {
                    return db.Products.Where(p => p.TillDescription.Contains(description)).Take(10).ToList();
                }

                return new List<Product>();
            }
        } 
    }
}