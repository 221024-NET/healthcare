using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Bill
    {
   
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
        public float Amount { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public int ReviewerID { get; set; }

        public Bill() { }
        public Bill(int id,int customerId, DateTime dateCreated, float amount, string detail,string status, int reviewerID)
        {
            Id = id;
            CustomerId = customerId;
            DateCreated = dateCreated;
            Amount = amount;
            Detail = detail;
            Status = status;
            ReviewerID = reviewerID;
        }
    }
}
