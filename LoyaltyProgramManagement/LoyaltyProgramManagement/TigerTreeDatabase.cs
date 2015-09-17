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
    }
}