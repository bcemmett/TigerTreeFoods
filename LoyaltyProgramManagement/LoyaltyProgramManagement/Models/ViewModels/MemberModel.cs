namespace LoyaltyProgramManagement.Models.ViewModels
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string MembershipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}