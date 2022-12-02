using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareAPI.Models
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; } 
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}