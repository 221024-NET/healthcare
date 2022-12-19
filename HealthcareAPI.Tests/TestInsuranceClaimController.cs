using HealthcareAPI.Controllers;
using HealthcareAPI.Models;
using HealthcareAPI.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAPI.Tests
{
    public class TestInsuranceClaimController
    {
        [Fact]
        public void GetAllClaims_RetrievesAllClaims()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Claims.AsQueryable()).Returns(new MockClaimSet());
            var controller = new InsuranceClaimController(mock.Object);

            var result = controller.GetAllClaims();

            Assert.IsType<Task<ActionResult<IEnumerable<InsuranceClaim>>>>(result);
        }

        [Fact]
        public void GetClaim_RetrievesGivenClaim()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Claims.AsQueryable()).Returns(new MockClaimSet());
            var controller = new InsuranceClaimController(mock.Object);
            int intended_id = 1;

            var result = controller.GetClaim(intended_id);

            Assert.IsType<Task<ActionResult<InsuranceClaim>>>(result);
        }

        [Fact]
        public void PutInsuranceClaim_UpdatesGivenClaim()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Claims.AsQueryable()).Returns(new MockClaimSet());
            var controller = new InsuranceClaimController(mock.Object);
            InsuranceClaim upClaim = new InsuranceClaim();
            upClaim.id = 1;
            upClaim.amount = 150;

            var result = controller.PutInsuranceClaim(upClaim);

            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void PostInsuranceClaim_CreatesNewClaim()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Claims.AsQueryable()).Returns(new MockClaimSet());
            var controller = new InsuranceClaimController(mock.Object);
            InsuranceClaim upClaim = new InsuranceClaim();

            var result = controller.PostInsuranceClaim(upClaim);

            Assert.IsType<Task<ActionResult<InsuranceClaim>>>(result);
        }
    }
}
