using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduCenter.Data;
using EduCenter.Entities;

namespace EduCenter.Controllers
{
    public class EnrollsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrolls
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrolls.Include(e => e.Course).Include(e => e.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enrolls
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // GET: Enrolls/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName");
            return View();
        }

        // POST: Enrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId")] Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", enroll.StudentId);
            return View(enroll);
        }

        // GET: Enrolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enrolls.FindAsync(id);
            if (enroll == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", enroll.StudentId);
            return View(enroll);
        }

        // POST: Enrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId")] Enroll enroll)
        {
            if (id != enroll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollExists(enroll.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", enroll.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName", enroll.StudentId);
            return View(enroll);
        }

        // GET: Enrolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enroll = await _context.Enrolls
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enroll == null)
            {
                return NotFound();
            }

            return View(enroll);
        }

        // POST: Enrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enroll = await _context.Enrolls.FindAsync(id);
            _context.Enrolls.Remove(enroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollExists(int id)
        {
            return _context.Enrolls.Any(e => e.Id == id);
        }
    }
}
