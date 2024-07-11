﻿using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        private const string ConnectionString = "Server=.;Database=StudentSystem;Integrated Security=True;";


        public StudentSystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
       
        public DbSet<Student>? Students { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<StudentCourse>? StudentsCourses { get; set; }

        public DbSet<Resource>? Resources { get; set; }

        public DbSet<Homework>? Homeworks { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
       //     optionsBuilder.UseSqlServer(ConnectionString);
      // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  направ на композитен ключ на мапинг таблица
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc=> new {sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsUnicode(false);
        }
    }
}
