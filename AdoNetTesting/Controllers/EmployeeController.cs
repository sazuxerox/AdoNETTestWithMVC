using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace AdoNetTesting.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            var employeeBusinessLayer = new EmployeeBusinessLayer();
            var employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }
	}
}