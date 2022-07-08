using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_App.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<Employee_App.Models.EmployeeInfo>());
        }
    }
}
