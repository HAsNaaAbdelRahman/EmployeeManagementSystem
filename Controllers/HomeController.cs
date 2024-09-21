using EmployeeManagementSystem.ApplicationDb;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            Repository.AddEmployee(employee);
            return View();
        }
        public ActionResult ShowAllEmployees()
        {
            var employees = Repository.GetEmployees();
            return View(employees);

        }
        public ActionResult Search(int id)
        {
            var employee = Repository.Search(id); 
            var employees = new List<Employee>();
            if (employee != null)
            {
                employees.Add(employee);
            }

            return View(employees); 
        }



        public IActionResult DeleteRecord(int id)
        {
            if (Repository.isFound(id) == false)
            {
                return View("NotFoundEmp");

            }
            Repository.DeleteEmployee(id);
            return RedirectToAction("ShowAllEmployees");
        }


        public IActionResult EditForm(int id)
        {
            var context = new ApplicationDbContext();

                var employee = context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null || employee.IsActive == false)
                {
                return View("NotFoundEmp");
                }
                return View(employee); 
            
        }
        [HttpPost]

        public IActionResult EditForm(Employee updatedEmployee)
        {

            Repository.UpdateEmployee(updatedEmployee);

            return RedirectToAction("index",controllerName:"Employee");



        }
    }
}
