using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAPI.Tests.Models
{
    public class MockEmployeeSet : MockDbSet<Employee>
    {
        List<Employee> employees = new List<Employee>();
        public MockEmployeeSet() 
        {
            employees.Add(new Employee()
            {
                employee_id = 1,
                name = "Tim",
                email = "test",
                password = "test1"
            });
            employees.Add(new Employee()
            {
                employee_id = 2,
                name = "Tam",
                email = "fest",
                password = "test2"
            });
            employees.Add(new Employee()
            {
                employee_id = 3,
                name = "Tom",
                email = "quest",
                password = "test3"
            });
        }
        public override async Task<Employee> FindAsync(params object[] keyValues)
        {
            return await this.SingleOrDefaultAsync<Employee>(emp => emp.employee_id == (int)keyValues.Single());
        }
    }
}
