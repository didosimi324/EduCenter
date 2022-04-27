using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduCenter.Models
{
    public class CreateStudentVM
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long. ", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Grade { get; set; }

    }
}
