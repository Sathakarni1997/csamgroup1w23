using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmployees);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Thanks",employee);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.Name ==
           empname).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Age =
           employee.Age;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Salary =
           employee.Salary;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Department
           = employee.Department;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().sex =
           employee.sex;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Name =
           employee.Name;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.Name ==
           empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }


    }
}
