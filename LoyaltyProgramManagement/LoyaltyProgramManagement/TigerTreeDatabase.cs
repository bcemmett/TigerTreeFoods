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
            if (String.IsNullOrWhiteSpace(membershipCode))
            {
                return SearchMembersByDetails(firstName, lastName, city, recentTransactions)
                    .Take(resultsToFetch)
                    .ToList();
            }
            else
            {
                return SearchMembersByMembershipCode(membershipCode)
                    .Take(resultsToFetch)
                    .ToList();
            }
        }

        private List<Member> SearchMembersByDetails(string firstName, string lastName, string city, bool recentTransactions)
        {
            using (var db = new TigerTreeFoodsContext())
            {
                List<Member> members = db.Members
                .Where(m =>
                    (m.FirstName == firstName || firstName == null || firstName == String.Empty)
                    && (m.LastName == lastName || lastName == null || lastName == String.Empty)
                    && (m.City == city || city == null || city == String.Empty)
                )
                .OrderBy(m => m.LastName)
                .ToList();

                if (recentTransactions)
                {
                    DateTime oneWeekAgo = DateTime.UtcNow.AddDays(-7);
                    members = members
                        .Where(m => m.Transactions
                            .Count(t => t.PurchaseDate > oneWeekAgo) > 0)
                        .ToList();
                }

                return members;
            }
        }

        private List<Member> SearchMembersByMembershipCode(string membershipCode)
        {
            using (var db = new TigerTreeFoodsContext())
            {
                IEnumerable<Member> membersByMembershipCode = db.Members.Where(m => m.MembershipCode == membershipCode);
                return membersByMembershipCode.ToList();
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