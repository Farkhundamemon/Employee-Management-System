using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var attendanceList = _context.Attendances.ToList();
            return View(attendanceList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Attendance att)
        {
            _context.Attendances.Add(att);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var att = _context.Attendances.Find(id);
            return View(att);
        }

        [HttpPost]
        public IActionResult Edit(Attendance att)
        {
            _context.Attendances.Update(att);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var att = _context.Attendances.Find(id);
            if (att != null)
            {
                _context.Attendances.Remove(att);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}