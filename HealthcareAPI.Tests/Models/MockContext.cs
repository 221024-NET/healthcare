using HealthcareAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAPI.Tests.Models
{
    public class MockContext
    {
        public static Mock<IContext> getMock()
        {
            var mock = new Mock<IContext>();

            mock.Setup(m => m.Claims.AsQueryable()).Returns(new MockClaimSet());
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());

            return mock;
        }
    }
}
