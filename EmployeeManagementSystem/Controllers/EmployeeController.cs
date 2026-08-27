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
            ViewBag.Designations = _context.Designations.ToList();
            ViewBag.Managers = _context.Employees.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp.status = "Active";

            var lastEmployee = _context.Employees.OrderByDescending(e => e.emp_id).FirstOrDefault();
            int nextNumber = lastEmployee != null ? lastEmployee.emp_id + 1 : 1;
            emp.employee_code = "EMP-" + nextNumber.ToString("D3");

            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            ViewBag.Designations = _context.Designations.ToList();
            ViewBag.Managers = _context.Employees.Where(e => e.emp_id != id).ToList();
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
                existing.gender = emp.gender;
                existing.date_of_birth = emp.date_of_birth;
                existing.cnic = emp.cnic;
                existing.address = emp.address;
                existing.emergency_contact = emp.emergency_contact;
                existing.Dep_id = emp.Dep_id;
                existing.designation = emp.designation;
                existing.employment_type = emp.employment_type;
                existing.joiningDate = emp.joiningDate;
                existing.salary = emp.salary;
                existing.password = emp.password;
                existing.reporting_manager_id = emp.reporting_manager_id;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return RedirectToAction("Index");

            var department = _context.Departments.FirstOrDefault(d => d.Dep_id == emp.Dep_id);
            var manager = emp.reporting_manager_id != null
                ? _context.Employees.FirstOrDefault(e => e.emp_id == emp.reporting_manager_id)
                : null;

            ViewBag.DepartmentName = department != null ? department.Dep_name : "N/A";
            ViewBag.ManagerName = manager != null ? manager.emp_name : "N/A";

            return View(emp);
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

            var oldStatus = emp.status;
            emp.status = "Deactivated";

            _context.EmployeeStatusHistories.Add(new EmployeeStatusHistory
            {
                emp_id = emp.emp_id,
                old_status = oldStatus,
                new_status = "Deactivated",
                changed_by = HttpContext.Session.GetString("AdminUsername") ?? "Admin",
                changed_date = DateTime.Now
            });

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

            var oldStatus = emp.status;
            emp.status = "Terminated";

            _context.EmployeeStatusHistories.Add(new EmployeeStatusHistory
            {
                emp_id = emp.emp_id,
                old_status = oldStatus,
                new_status = "Terminated",
                changed_by = HttpContext.Session.GetString("AdminUsername") ?? "Admin",
                changed_date = DateTime.Now
            });

            _context.SaveChanges();
            TempData["Message"] = "Employee has been terminated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Reactivate(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return RedirectToAction("Index");

            var oldStatus = emp.status;
            emp.status = "Active";

            _context.EmployeeStatusHistories.Add(new EmployeeStatusHistory
            {
                emp_id = emp.emp_id,
                old_status = oldStatus,
                new_status = "Active",
                changed_by = HttpContext.Session.GetString("AdminUsername") ?? "Admin",
                changed_date = DateTime.Now
            });

            _context.SaveChanges();
            TempData["Message"] = "Employee has been reactivated successfully and can now access the system.";
            return RedirectToAction("Index");
        }
    }
}