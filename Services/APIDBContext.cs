using APIBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace APIBackend.Services
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient>? Patient { get; set; }

        public DbSet<Doctor>? Doctor { get; set; }

        public DbSet<Hospital>? Hospital { get; set; }

        public DbSet<Appointment>? Appointment { get; set; }
    }
}
