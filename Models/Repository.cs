using EmployeeManagementSystem.ApplicationDb;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace EmployeeManagementSystem.Models
{
    public class Repository
    {
        private static List<Employee> EmployeesList = new List<Employee>();


        public static IEnumerable<Employee> GetEmployees()
        {
            var context = new ApplicationDbContext();
            var employees = context.Employees;
            return employees;
            
        }

        public static void AddEmployee(Employee emp)
        {
            var context = new ApplicationDbContext();
            context.Employees.Add(emp);
            context.SaveChanges();

        }

        public static void UpdateEmployee(Employee NewEmp)
        {
            var context = new ApplicationDbContext();

            var employee = context.Employees.FirstOrDefault(e => e.Id == NewEmp.Id);

            if (employee != null)
            {
                employee.Name = NewEmp.Name;
                context.SaveChanges();
            }

        }

        public static void DeleteEmployee(int id)
        {
            var context = new ApplicationDbContext();
            var emp = context.Employees.FirstOrDefault(i => i.Id == id);
            if (emp != null)
            {
                emp.IsActive = false;
                context.SaveChanges();
            }
        }
        public static Employee? Search(int id)
        {
            var context = new ApplicationDbContext();
            if (isFound(id))
            {
                var emp = context.Employees.FirstOrDefault(x => x.Id == id);
                return emp;
            }
            return null;
        }

        public static bool isFound(int id)
        {
            var context = new ApplicationDbContext();
            return context.Employees.Any(x => x.Id == id);
        }
    }
}
