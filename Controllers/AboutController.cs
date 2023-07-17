using CasgemPortfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        CasgemPortfolioEntities4 db = new CasgemPortfolioEntities4();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialAboutMe()
        {
            ViewBag.title = db.TblWhoAmI.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = db.TblWhoAmI.Select(x => x.Description).FirstOrDefault();
            ViewBag.mail = db.TblContact.Select(x => x.Mail).FirstOrDefault();
            ViewBag.nameSurname = db.TblContact.Select(x => x.NameSurname).FirstOrDefault();
            ViewBag.age = db.TblContact.Select(x => x.Age).FirstOrDefault();
            ViewBag.city = db.TblContact.Select(x => x.Age).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialAboutMe2()
        {
            return PartialView();
        }

        public PartialViewResult PartialAchievement()
        {
            var values = db.TblAchievement.ToList();

            return PartialView(values);
        }
    }
}