using Agenzia_viaggio_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenzia_viaggio_mvc.Database {
    public class AgenziaContext : DbContext {
        public DbSet<Tour> Tours { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=ToursDB;Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
