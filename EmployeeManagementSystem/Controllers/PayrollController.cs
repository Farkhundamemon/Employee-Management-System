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
            // Gross Salary = Basic + Allowances
            payroll.gross_salary = payroll.basic_salary + payroll.allowances;

            decimal yearlyIncome = payroll.gross_salary * 12;
            decimal yearlyTax = 0;

            if (yearlyIncome <= 600000)
            {
                yearlyTax = 0;
            }
            else if (yearlyIncome <= 1200000)
            {
                yearlyTax = (yearlyIncome - 600000) * 0.15m;
            }
            else if (yearlyIncome <= 2200000)
            {
                yearlyTax = 90000 + (yearlyIncome - 1200000) * 0.20m;
            }
            else if (yearlyIncome <= 3200000)
            {
                yearlyTax = 170000 + (yearlyIncome - 2200000) * 0.30m;
            }
            else if (yearlyIncome <= 4100000)
            {
                yearlyTax = 650000 + (yearlyIncome - 3200000) * 0.40m;
            }
            else
            {
                yearlyTax = 1610000 + (yearlyIncome - 4100000) * 0.45m;
            }

            payroll.tax = Math.Round(yearlyTax / 12, 2);

            // Automatic PF Employee Share (example: 8% of Basic Salary)
            payroll.pf_employee_share = Math.Round(payroll.basic_salary * 0.08m, 2);

            // Automatic Loan Deduction — check if employee has an active loan
            var activeLoan = _context.Loans.FirstOrDefault(l => l.emp_id == payroll.emp_id && l.status == "Active");
            if (activeLoan != null)
            {
                payroll.loan_deduction = activeLoan.monthly_installment;

                // Reduce the loan's remaining balance
                activeLoan.remaining_balance -= activeLoan.monthly_installment;
                if (activeLoan.remaining_balance <= 0)
                {
                    activeLoan.remaining_balance = 0;
                    activeLoan.status = "Completed";
                }
            }
            else
            {
                payroll.loan_deduction = 0;
            }

            // Total Deduction = Tax + PF + Loan
            payroll.deduction = payroll.tax + payroll.pf_employee_share + payroll.loan_deduction;

            // Net Salary = Gross - Total Deduction
            payroll.net_salary = payroll.gross_salary - payroll.deduction;

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
            payroll.gross_salary = payroll.basic_salary + payroll.allowances;

            decimal yearlyIncome = payroll.gross_salary * 12;
            decimal yearlyTax = 0;

            if (yearlyIncome <= 600000)
            {
                yearlyTax = 0;
            }
            else if (yearlyIncome <= 1200000)
            {
                yearlyTax = (yearlyIncome - 600000) * 0.15m;
            }
            else if (yearlyIncome <= 2200000)
            {
                yearlyTax = 90000 + (yearlyIncome - 1200000) * 0.20m;
            }
            else if (yearlyIncome <= 3200000)
            {
                yearlyTax = 170000 + (yearlyIncome - 2200000) * 0.30m;
            }
            else if (yearlyIncome <= 4100000)
            {
                yearlyTax = 650000 + (yearlyIncome - 3200000) * 0.40m;
            }
            else
            {
                yearlyTax = 1610000 + (yearlyIncome - 4100000) * 0.45m;
            }

            payroll.tax = Math.Round(yearlyTax / 12, 2);
            payroll.pf_employee_share = Math.Round(payroll.basic_salary * 0.08m, 2);
            payroll.deduction = payroll.tax + payroll.pf_employee_share + payroll.loan_deduction;
            payroll.net_salary = payroll.gross_salary - payroll.deduction;

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

        public IActionResult MarkPaid(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            if (payroll != null)
            {
                payroll.payment_status = "Paid";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}