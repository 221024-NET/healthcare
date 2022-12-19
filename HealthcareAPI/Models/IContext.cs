using Microsoft.EntityFrameworkCore;

namespace HealthcareAPI.Models
{
    public interface IContext
    {
        public DbSet<InsuranceClaim> Claims { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public void DenoteEmployeeModified(Employee emp);
        public void DenotePatientModified(Patient pat);
        public Task CommitChangesAsync();
    }
}
