using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
            
        }

        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = @"C:\Users\DELL\Downloads\Telegram Desktop\StudentRegistrationSystem\StudentRegistrationSystem\StudentData.db"; // Replace with the actual path to your UserData.db file
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }



        public DbSet<Student> Students { get; set; }

        public DbSet<StudentModule> StudentModules { get; set; }
        public DbSet<Module> Modules { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModule>()
            .HasKey(sm => new { sm.StudentId, sm.ModuleId});
            modelBuilder.Entity<StudentModule>()
       .Property(x => x.Version)
       .HasDefaultValueSql("X'01'")
       .IsConcurrencyToken();

            modelBuilder.Entity<StudentModule>()
        .Property(e => e.Score) // configure the Score property
        .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            base.OnModelCreating(modelBuilder);

        }
    }
}
