using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeePortalController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeePortalController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var empId = HttpContext.Session.GetInt32("EmployeeId");
            if (empId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var employee = _context.Employees.FirstOrDefault(e => e.emp_id == empId);
            var attendance = _context.Attendances.Where(a => a.emp_id == empId).OrderByDescending(a => a.date).Take(5).ToList();
            var leaves = _context.Leaves.Where(l => l.emp_id == empId).ToList();
            var payroll = _context.Payrolls.Where(p => p.emp_id == empId).OrderByDescending(p => p.payroll_id).ToList();

            ViewBag.Employee = employee;
            ViewBag.Attendance = attendance;
            ViewBag.Leaves = leaves;
            ViewBag.Payroll = payroll;

            return View();
        }

        public IActionResult RequestLeave()
        {
            var empId = HttpContext.Session.GetInt32("EmployeeId");
            if (empId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult RequestLeave(Leave leave)
        {
            var empId = HttpContext.Session.GetInt32("EmployeeId");
            if (empId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            leave.emp_id = empId.Value;
            leave.status = "Pending";

            _context.Leaves.Add(leave);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }
    }
}