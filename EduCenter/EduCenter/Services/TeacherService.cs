using EduCenter.Abstractions;
using EduCenter.Data;
using EduCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;

        public TeacherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string firstname, string lastname, string phone, string speciality, string userId)
        {
            if (_context.Teachers.Any(p => p.UserId == userId))
            {
                throw new InvalidOperationException("Teacher already exist.");
            }
            Teacher employeeForDb = new Teacher()
            {
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Speciality = speciality,
                UserId = userId
            };

            _context.Teachers.Add(employeeForDb);

            return _context.SaveChanges() != 0;
        }
    }
}
