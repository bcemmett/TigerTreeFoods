using System.Collections.Generic;
using System.ComponentModel;

namespace LoyaltyProgramManagement.Models.ViewModels
{
    public class MembersTableModel
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Town / city")]
        public string City { get; set; }
        [DisplayName("Recent transactions")]
        public bool RecentTransactions { get; set; }
        [DisplayName("Membership code")]
        public string MembershipCode { get; set; }
        [DisplayName("Results to display")]
        public int ResultsToDisplay { get; set; }
        [DisplayName("Members")]
        public List<MemberModel> Members { get; set; }
    }
}