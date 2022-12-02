using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAPI.Models
{
    public class InsuranceClaim
    {
   
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public float Amount { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public int ReviewerID { get; set; }

        public InsuranceClaim() { }

        public InsuranceClaim(int customerId, float amount, string detail)
        {
            this.CustomerId = customerId;
            this.DateCreated = DateTime.Now;
            this.Amount = amount;
            this.Detail = detail;
            this.Status = "Pending";
        }
        public InsuranceClaim(int id, int customerId, DateTime dateCreated, float amount, string detail,string status, int reviewerID)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.DateCreated = dateCreated;
            this.Amount = amount;
            this.Detail = detail;
            this.Status = status;
            this.ReviewerID = reviewerID;
        }
    }
}
