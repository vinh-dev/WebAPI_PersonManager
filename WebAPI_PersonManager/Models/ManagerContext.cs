using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_PersonManager.Models
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }
        public DbSet<Person> PersonItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("tblPerson");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
