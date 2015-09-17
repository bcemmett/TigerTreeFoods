using System;
using System.Collections.Generic;
using System.Linq;
using LoyaltyProgramManagement.Models;

namespace LoyaltyProgramManagement
{
    public class TigerTreeDatabase
    {
        public List<Member> SearchMembers(string firstName, string lastName, string city, string membershipCode, bool recentTransactions)
        {
            var members = new List<Member>();
            using (var db = new TigerTreeFoodsContext())
            {
                members = db.Members.
                    Where(m => 
                        (m.FirstName == firstName || firstName == null || firstName == String.Empty)
                        && (m.LastName == lastName || lastName == null || lastName == String.Empty)
                        && (m.City == city || city == null || city == String.Empty)
                        && (m.MembershipCode == membershipCode || membershipCode == null || membershipCode == String.Empty)
                    )
                    .Take(50)
                    .ToList();
            }
            return members;
        }
    }
}