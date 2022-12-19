using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAPI.Tests.Models
{
    public class MockPatientSet : MockDbSet<Patient>
    {
        List<Patient> patients = new List<Patient>();
        public MockPatientSet() 
        {
            patients.Add(new Patient
            {
                patient_id = 1,
                name = "Pam",
                email = "test1",
                password = "salt"
            });
            patients.Add(new Patient
            {
                patient_id = 2,
                name = "Pom",
                email = "test2",
                password = "sault"
            });
            patients.Add(new Patient
            {
                patient_id = 3,
                name = "Pum",
                email = "test3",
                password = "solt"
            });
        }
        public override async Task<Patient> FindAsync(params object[] keyValues)
        {
            return await this.SingleOrDefaultAsync<Patient>(pat => pat.patient_id == (int)keyValues.Single());
        }
    }
}
