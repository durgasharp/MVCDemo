using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer emloyeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = emloyeeBusinessLayer.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")] 
        public ActionResult Create_Get()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Create")]      
        public ActionResult Create_Post(Employee employee)
        {
            
          //  Employee employee = new Employee();
           // TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer emloyeeBusinessLayer = new EmployeeBusinessLayer();
                emloyeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer emloyeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = emloyeeBusinessLayer.Employees.Single(emp => emp.ID == id);
           
           return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer emloyeeBusinessLayer = new EmployeeBusinessLayer();

                emloyeeBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index");

            }
            
            return View();
        }
    }
}