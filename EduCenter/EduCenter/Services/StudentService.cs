using EduCenter.Abstractions;
using EduCenter.Data;
using EduCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EduCenter.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string firstname, string lastname, string phone, int grade, string userId)
        {
            if (_context.Students.Any(p => p.UserId == userId))
            {
                throw new InvalidOperationException("Student already exist.");
            }
            Student studentForDb = new Student()
            {
                FirstName = firstname,
                LastName = lastname,
                Phone = phone,
                Grade = grade,
                UserId = userId
            };

            _context.Students.Add(studentForDb);

            return _context.SaveChanges() != 0;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = _context.Students.ToList();

            return students;
        }
    }
}
