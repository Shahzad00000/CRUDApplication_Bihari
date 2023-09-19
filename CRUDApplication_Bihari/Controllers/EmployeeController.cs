using CRUDApplication_Bihari.Context;
using CRUDApplication_Bihari.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CRUDApplication_Bihari.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _Context;

        public EmployeeController(ApplicationDBContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var Data = _Context.Employees.ToList();
            return View(Data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee();
                {
                    emp.Name = Model.Name;
                    emp.State = Model.State;
                    emp.City = Model.City;
                    emp.Salary = Model.Salary;
                };
                _Context.Employees.Add(emp);
                _Context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");   
            }
            else
            {
                TempData["error"] = "Empty Field Can't Submit";
                return View(Model);
            }           
        }
        public IActionResult Delete(int id)
        {
            var Data=_Context.Employees.Where(x=>x.Id==id).FirstOrDefault();
            _Context.Employees.Remove(Data);
            _Context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = _Context.Employees.Where(x => x.Id == id).FirstOrDefault();
            var result=new Employee();
            {
                result.Name=emp.Name;
                result.State=emp.State;
                result.City=emp.City;
                result.Salary=emp.Salary;
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee Model)
        {
            var emp=new Employee();
            {
                emp.Id=Model.Id;
                emp.Name=Model.Name;
                emp.State=Model.State;
                emp.City=Model.City;
                emp.Salary=Model.Salary;
            };
            _Context.Employees.Update(emp);
            _Context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var Data = _Context.Employees.Where(x => x.Id == id).SingleOrDefault();
            return View(Data);
        }
    }
}
