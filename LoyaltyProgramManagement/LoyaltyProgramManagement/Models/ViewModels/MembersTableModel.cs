using System.Collections.Generic;

namespace LoyaltyProgramManagement.Models.ViewModels
{
    public class MembersTableModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public bool RecentTransactions { get; set; }
        public string MembershipCode { get; set; }
        public int ResultsToDisplay { get; set; }
        public List<MemberModel> Members { get; set; }
    }
}