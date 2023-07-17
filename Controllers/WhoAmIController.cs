using CasgemPortfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    
    public class WhoAmIController : Controller
    {
        CasgemPortfolioEntities4 db = new CasgemPortfolioEntities4();
        public ActionResult Index()
        {
            var values = db.TblWhoAmI.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateWhoAmI(int id)
        {
            var value = db.TblWhoAmI.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWhoAmI(TblWhoAmI p)
        {
            var value = db.TblWhoAmI.Find(p.WhoId);
            value.Title = p.Title;
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}