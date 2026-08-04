using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class PayrollController : Controller
    {
        private readonly AppDbContext _context;

        public PayrollController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var payrolls = _context.Payrolls.ToList();
            return View(payrolls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Payroll payroll)
        {
            payroll.net_salary = payroll.basic_salary - payroll.deduction;
            _context.Payrolls.Add(payroll);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            return View(payroll);
        }

        [HttpPost]
        public IActionResult Edit(Payroll payroll)
        {
            payroll.net_salary = payroll.basic_salary - payroll.deduction;
            _context.Payrolls.Update(payroll);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            if (payroll != null)
            {
                _context.Payrolls.Remove(payroll);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}