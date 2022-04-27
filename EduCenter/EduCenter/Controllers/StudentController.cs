using EduCenter.Abstractions;
using EduCenter.Data;
using EduCenter.Entities;
using EduCenter.Models;
using EduCenter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduCenter.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentController(IStudentService studentService, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _studentService = studentService;
            _userManager = userManager;
            _context = context;
        }

                
        public ActionResult Index()
        {
            var students = _context.Students;
            return View(students);
        }
                
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeachersController/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentVM student)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userIdAlreadyClient = this._studentService
                .GetStudents()
                .Any(d => d.UserId == userId);

            if (!ModelState.IsValid)
            {
                return View(student);
            }
            var created = _studentService.Create(student.FirstName, student.LastName, student.Phone, student.Grade, userId);


            if (created)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
