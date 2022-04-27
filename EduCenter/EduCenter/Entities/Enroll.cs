using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Entities
{
    public class Enroll
    {
        [Required]
        [Key]
        public int Id { set; get; }
        [Required]
        public int StudentId { set; get; }
        public virtual Student Student { get; set; }

        [Required]
        public int CourseId { set; get; }
        public virtual Course Course { get; set; }
    }
}
