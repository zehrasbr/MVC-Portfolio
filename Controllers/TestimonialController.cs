using CasgemPortfolio.Models.Entities;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        CasgemPortfolioEntities4 db = new CasgemPortfolioEntities4();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {
            if (Request.Files.Count > 0)
            {

                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string ext = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/image/" + fileName + ext;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.ImageURL = "/image/" + fileName + ext;

            }
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.TblTestimonial.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var values = db.TblTestimonial.Find(p.TestimonialId);
            values.NameSurname = p.NameSurname;
            values.TestimonialContent = p.TestimonialContent;
            values.Country = p.Country;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}