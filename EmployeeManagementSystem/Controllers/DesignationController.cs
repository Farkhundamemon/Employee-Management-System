using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class DesignationController : Controller
    {
        private readonly AppDbContext _context;

        public DesignationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var designations = _context.Designations.ToList();
            var departments = _context.Departments.ToList();

            ViewBag.Departments = departments;
            return View(designations);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Designation designation)
        {
            _context.Designations.Add(designation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var designation = _context.Designations.Find(id);
            ViewBag.Departments = _context.Departments.ToList();
            return View(designation);
        }

        [HttpPost]
        public IActionResult Edit(Designation designation)
        {
            _context.Designations.Update(designation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var designation = _context.Designations.Find(id);
            if (designation != null)
            {
                _context.Designations.Remove(designation);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}