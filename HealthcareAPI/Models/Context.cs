using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HealthcareAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<InsuranceClaim> Claims { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
    }
}
