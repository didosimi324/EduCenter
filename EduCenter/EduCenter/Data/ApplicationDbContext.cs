using EduCenter.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EduCenter.Models;

namespace EduCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Enroll> Enrolls { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<EduCenter.Models.CreateStudentVM> CreateStudentVM { get; set; }
        
    }
}
