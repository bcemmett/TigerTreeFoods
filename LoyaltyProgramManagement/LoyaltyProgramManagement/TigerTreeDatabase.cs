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
                if (!String.IsNullOrWhiteSpace(firstName))
                {
                    members = db.Members.Where(m => m.FirstName == firstName).Take(50).ToList();
                }
            }
            return members;
        }
    }
}