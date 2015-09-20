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

        [HttpPost]
        public ActionResult Products(ProductsTableModel model)
        {
            var db = new TigerTreeDatabase();
            List<Product> products = db.SearchProducts(model.Barcode, model.Description);
            model.Products = products.Select(p => p.ToProductModel()).ToList();
            return View(model);
        }
        
        public ActionResult Products()
        {
            var model = new ProductsTableModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Members(MembersTableModel model)
        {
            var db = new TigerTreeDatabase();
            List<Member> members = db.SearchMembers(model.ResultsToDisplay, model.FirstName, model.LastName, model.City, model.MembershipCode, model.RecentTransactions);
            model.Members = members.Select(m => m.ToMemberModel()).ToList();
            return View(model);
        }
        
        public ActionResult Members()
        {
            var model = new MembersTableModel();
            return View(model);
        }
    }
}