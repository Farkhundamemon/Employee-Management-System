using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.emp_name.Contains(search) || e.emp_email.Contains(search));
            }

            ViewBag.Search = search;
            return View(employees.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp.status = "Active";
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var existing = _context.Employees.Find(emp.emp_id);
            if (existing != null)
            {
                existing.emp_name = emp.emp_name;
                existing.emp_email = emp.emp_email;
                existing.phone = emp.phone;
                existing.Dep_id = emp.Dep_id;
                existing.designation = emp.designation;
                existing.joiningDate = emp.joiningDate;
                existing.salary = emp.salary;
                existing.password = emp.password;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Deactivate(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return RedirectToAction("Index");

            if (emp.status == "Deactivated")
            {
                TempData["Message"] = "This employee is already deactivated.";
                return RedirectToAction("Index");
            }

            emp.status = "Deactivated";
            _context.SaveChanges();
            TempData["Message"] = "Employee has been deactivated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Terminate(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return RedirectToAction("Index");

            if (emp.status == "Terminated")
            {
                TempData["Message"] = "This employee is already terminated. No further action is required.";
                return RedirectToAction("Index");
            }

            emp.status = "Terminated";
            _context.SaveChanges();
            TempData["Message"] = "Employee has been terminated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Reactivate(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return RedirectToAction("Index");

            emp.status = "Active";
            _context.SaveChanges();
            TempData["Message"] = "Employee has been reactivated successfully and can now access the system.";
            return RedirectToAction("Index");
        }
    }
}