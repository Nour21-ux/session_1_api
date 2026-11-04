using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using session_1.Entities;
using System.Reflection;

namespace session_1.Data
{
    public class ApplicationDbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=>optionsBuilder.UseSqlServer("Server = WIN - Q276OV7M5CH\\SQLEXPRESS; DataBase=Health_Care_System_Api;Trusted_Connection=True;TrustServerCertificate=True;");

        public ApplicationDbContext(DbContextOptions options):base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
