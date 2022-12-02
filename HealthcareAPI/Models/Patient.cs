using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareAPI.Models
{
    
    public class Patient
    {
        [Key]
        public int patient_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
