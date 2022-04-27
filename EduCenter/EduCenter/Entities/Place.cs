using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Entities
{
    public class Place
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public int Capacity { set; get; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
