using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Abstractions
{
    public interface ITeacherService
    {
        bool Create(string firstname, string lastname, string phone, string speciality, string userId);
    }
}
