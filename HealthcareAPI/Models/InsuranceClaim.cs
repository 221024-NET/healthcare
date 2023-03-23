using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareAPI.Models
{
    public class InsuranceClaim
    {
        [Key]
        public int id { get; set; }
        public int customer_id { get; set; }
        public DateTime date_submitted { get; set; }
        public double amount { get; set; }
        public string details { get; set; }
        public string status { get; set; }
        public int? reviewed_by { get; set; }
    }
}
