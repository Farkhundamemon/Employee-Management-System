using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class LeaveController : Controller
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leaves = _context.Leaves.ToList();
            return View(leaves);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Leave leave)
        {
            _context.Leaves.Add(leave);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var leave = _context.Leaves.Find(id);
            return View(leave);
        }

        [HttpPost]
        public IActionResult Edit(Leave leave)
        {
            _context.Leaves.Update(leave);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var leave = _context.Leaves.Find(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Approve(int id)
        {
            var leave = _context.Leaves.Find(id);
            if (leave != null)
            {
                leave.status = "Approved";
                leave.approved_by = HttpContext.Session.GetString("AdminUsername") ?? "Admin";
                leave.approved_date = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Reject(int id)
        {
            var leave = _context.Leaves.Find(id);
            if (leave != null)
            {
                leave.status = "Rejected";
                leave.approved_by = HttpContext.Session.GetString("AdminUsername") ?? "Admin";
                leave.approved_date = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}