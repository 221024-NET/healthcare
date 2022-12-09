
using HealthcareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    internal interface IPaitentRepository
    {
        public Patient CreateNewPaitent(Patient paitent, string conn);
        public Patient GetPaitentByID(int id, string conn);
        public IEnumerable<Patient> GetAllPaitents(string conn);
        public Patient LogInPaitent(Patient patient, string conn);
    }
}
