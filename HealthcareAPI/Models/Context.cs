using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HealthcareAPI.Models
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Bill> Claims { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public void DenoteEmployeeModified(Employee emp) { Entry(emp).State = EntityState.Modified; }
        public void DenotePatientModified(Patient pat) { Entry(pat).State = EntityState.Modified; }
        public Task CommitChangesAsync() { return SaveChangesAsync(); }
    }
}
