﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concetes.EntityFramework
{
    public class TobetoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TobetoCourseAcademyDb;Trusted_Connection=true");
        }
        public DbSet<Category>  Categories{ get; set; }
        public DbSet<Course>  Courses{ get; set; }
    }
}
