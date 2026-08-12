using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.ActiveEmployees = _context.Employees.Count(e => e.status == "Active");
            ViewBag.DeactivatedEmployees = _context.Employees.Count(e => e.status == "Deactivated");
            ViewBag.TerminatedEmployees = _context.Employees.Count(e => e.status == "Terminated");
            ViewBag.TotalDepartments = _context.Departments.Count();
            ViewBag.PresentToday = _context.Attendances.Count(a => a.status == "Present");
            ViewBag.PendingLeaves = _context.Leaves.Count(l => l.status == "Pending");
            ViewBag.TotalPayroll = _context.Payrolls.Sum(p => (decimal?)p.net_salary) ?? 0;

            var recentEmployees = _context.Employees.OrderByDescending(e => e.emp_id).Take(5).ToList();
            ViewBag.RecentEmployees = recentEmployees;

            return View();
        }
    }
}