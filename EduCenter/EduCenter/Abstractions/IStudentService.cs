using EduCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Abstractions
{
    public interface IStudentService
    {
        bool Create(string firstname, string lastname, string phone, int Grade, string userId);
        public List<Student> GetStudents();
    }
}
