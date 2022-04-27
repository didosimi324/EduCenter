using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Entities
{
    public class Course
    {
        [Key]
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public DateTime Start { set; get; }
        public DateTime End { set; get; }
        public int PlaceId { set; get; }
        public virtual Place Place { get; set; }

        public decimal Price { set; get; }
        public int CountStudents { set; get; }
        public int TeacherId { set; get; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();



    }
}
