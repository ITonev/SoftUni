using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        //public DbSet<ResourceType> ResourceTypes { get; set; }

        //public DbSet<ContentType> ContentTypes { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=PRETORIAN\SQLEXPRESS;Database=StudentSystem;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(k => new { k.CourseId, k.StudentId });

            modelBuilder.Entity<Student>(student =>
            {
                student
                .Property(p => p.Name).IsRequired().HasMaxLength(100).IsUnicode(true);

                student
                .Property(p => p.PhoneNumber).HasMaxLength(10).IsFixedLength(true);
            });

        }
    }
}
