using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeesByDepartment()
        {
            var report = _context.Employees
                .GroupBy(e => e.Dep_id)
                .Select(g => new
                {
                    DepartmentId = g.Key,
                    EmployeeCount = g.Count()
                })
                .ToList();

            var departments = _context.Departments.ToList();

            var finalReport = report.Select(r => new
            {
                DepartmentName = departments.FirstOrDefault(d => d.Dep_id == r.DepartmentId) != null
                    ? departments.First(d => d.Dep_id == r.DepartmentId).Dep_name
                    : "Unknown",
                r.EmployeeCount
            }).ToList();

            ViewBag.Report = finalReport;
            return View();
        }

        public IActionResult PayrollSummary()
        {
            var totalPaid = _context.Payrolls.Sum(p => (decimal?)p.net_salary) ?? 0;
            var totalDeductions = _context.Payrolls.Sum(p => (decimal?)p.deduction) ?? 0;
            var totalRecords = _context.Payrolls.Count();

            ViewBag.TotalPaid = totalPaid;
            ViewBag.TotalDeductions = totalDeductions;
            ViewBag.TotalRecords = totalRecords;

            return View();
        }

        public IActionResult LeaveSummary()
        {
            var pending = _context.Leaves.Count(l => l.status == "Pending");
            var approved = _context.Leaves.Count(l => l.status == "Approved");
            var rejected = _context.Leaves.Count(l => l.status == "Rejected");

            ViewBag.Pending = pending;
            ViewBag.Approved = approved;
            ViewBag.Rejected = rejected;

            return View();
        }

        public IActionResult AttendanceSummary()
        {
            var present = _context.Attendances.Count(a => a.status == "Present");
            var absent = _context.Attendances.Count(a => a.status == "Absent");
            var late = _context.Attendances.Count(a => a.status == "Late");

            ViewBag.Present = present;
            ViewBag.Absent = absent;
            ViewBag.Late = late;

            return View();
        }

        public IActionResult ActiveEmployees()
        {
            var employees = _context.Employees.Where(e => e.status == "Active").ToList();
            var departments = _context.Departments.ToList();

            ViewBag.Employees = employees;
            ViewBag.Departments = departments;
            return View();
        }

        public IActionResult TerminatedEmployees()
        {
            var employees = _context.Employees.Where(e => e.status == "Terminated").ToList();
            var departments = _context.Departments.ToList();

            ViewBag.Employees = employees;
            ViewBag.Departments = departments;
            return View();
        }
        public IActionResult DeactivatedEmployees()
        {
            var employees = _context.Employees.Where(e => e.status == "Deactivated").ToList();
            var departments = _context.Departments.ToList();

            ViewBag.Employees = employees;
            ViewBag.Departments = departments;
            return View();
        }

        public IActionResult DepartmentSummary()
        {
            var departments = _context.Departments.ToList();
            var employees = _context.Employees.ToList();

            var summary = departments.Select(d => new
            {
                DepartmentName = d.Dep_name,
                TotalEmployees = employees.Count(e => e.Dep_id == d.Dep_id),
                ActiveEmployees = employees.Count(e => e.Dep_id == d.Dep_id && e.status == "Active")
            }).ToList();

            ViewBag.Summary = summary;
            return View();
        }

        public IActionResult StatusHistory()
        {
            var history = _context.EmployeeStatusHistories.OrderByDescending(h => h.changed_date).ToList();
            var employees = _context.Employees.ToList();

            ViewBag.History = history;
            ViewBag.Employees = employees;
            return View();
        }
    }
}