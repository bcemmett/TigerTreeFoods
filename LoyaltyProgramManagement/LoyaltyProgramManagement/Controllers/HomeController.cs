using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LoyaltyProgramManagement.Models;
using LoyaltyProgramManagement.Models.ViewModels;

namespace LoyaltyProgramManagement.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return new RedirectResult("Home/Members");
        }
        
        public ActionResult Members()
        {
            using (var db = new TigerTreeFoodsContext())
            {
                IEnumerable<Member> members = db.Members.Take(50).ToList();
                var model = new MembersTableModel();
                model.Members = members.Select(m => new MemberModel
                {
                    MemberId = m.MemberId,
                    MembershipCode = m.MembershipCode,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Address1 = m.Address1,
                    Address2 = m.Address2,
                    PostCode = m.PostCode,
                    City = m.City
                }).ToList();
                
                return View(model);
            }
        }
    }
}