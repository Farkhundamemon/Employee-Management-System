using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.username == username && a.password == password);

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminUsername", admin.username);
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToAction("Index", "Home");
            }

            var employee = _context.Employees.FirstOrDefault(e => e.emp_email == username && e.password == password);

            if (employee != null)
            {
                HttpContext.Session.SetString("EmployeeEmail", employee.emp_email);
                HttpContext.Session.SetInt32("EmployeeId", employee.emp_id);
                HttpContext.Session.SetString("UserRole", "Employee");
                return RedirectToAction("Dashboard", "Employee");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}