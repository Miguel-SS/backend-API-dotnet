using APIBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace APIBackend.Services
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient>? Patient { get; set; }
    }
}
