using EduCenter.Abstractions;
using EduCenter.Data;
using EduCenter.Entities;
using EduCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public TeachersController(ITeacherService teacherService, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _teacherService = teacherService;
            _userManager = userManager;
            _context = context;
        }



        // GET: TeachersController
        public ActionResult Index()
        {
            var teachers = _context.Teachers;
            return View(teachers);
        }

        // GET: TeachersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeachersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeachersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTeacherVM teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            if (await _userManager.FindByNameAsync
                           (teacher.Username) == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = teacher.Username;
                user.Email = teacher.Email;


                var result = await _userManager.CreateAsync(user, "123456");

                if (result.Succeeded)
                {
                    var created = _teacherService.Create(teacher.FirstName, teacher.LastName,
                        teacher.Phone, teacher.Speciality, user.Id);
                    if (created)
                    {
                        _userManager.AddToRoleAsync(user, "Teacher").Wait();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "The teacher exists.");
            return View();
        }

        // GET: TeachersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeachersController/Edit/5
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

        // GET: TeachersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeachersController/Delete/5
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
