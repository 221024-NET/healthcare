using HealthcareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAPI.Tests.Models
{
    public class MockClaimSet : MockDbSet<InsuranceClaim>
    {
        List<InsuranceClaim> claims = new List<InsuranceClaim>();
        public MockClaimSet()
        {
            claims.Add(new InsuranceClaim()
            {
                id = 1,
                customer_id = 1,
                date_submitted = DateTime.Now,
                amount = 50,
                details = "test1",
                status = "Pending"
            });
            claims.Add(new InsuranceClaim()
            {
                id = 2,
                customer_id = 1,
                date_submitted = DateTime.Now,
                amount = 150,
                details = "test2",
                status = "Accepted"
            });
            claims.Add(new InsuranceClaim()
            {
                id = 3,
                customer_id = 2,
                date_submitted = DateTime.Now,
                amount = 1050,
                details = "test3",
                status = "Denied"
            });
        }
    }
}
