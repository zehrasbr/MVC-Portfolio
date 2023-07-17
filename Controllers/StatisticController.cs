using CasgemPortfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        CasgemPortfolioEntities4 db = new CasgemPortfolioEntities4();
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();

            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(
                y => y.EmployeeName + " " + y.EmployeeSurName).FirstOrDefault();


            ViewBag.totalCityCount = db.TblEmployee.Select(x => x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);

            ViewBag.countSoftwareDepartment = db.TblEmployee.Where(
                x => x.EmployeeDepartment == db.TblDepartment.Where(
                    z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentId).FirstOrDefault()).Count();

            ViewBag.cityAdanaOrAnkaraTotalSalary = db.TblEmployee.Where(
                x => x.EmployeeCity == "Ankara" || x.EmployeeCity == "Adana").Sum(y => y.EmployeeSalary);

            ViewBag.sumSalaryFromSoftwareDepartment = db.TblEmployee.Where(
                x => x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDepartment.Where(
                    z => z.DepartmentName == "Yazılım").Select(
                    y => y.DepartmentId).FirstOrDefault()).Sum(y => y.EmployeeSalary);

            return View();
        }
    }
}