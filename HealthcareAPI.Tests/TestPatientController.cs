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
using Xunit.Sdk;

namespace HealthcareAPI.Tests
{
    public class TestPatientController
    {
        [Fact]
        public void GetAllPatients_RetrievesAllPatients()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);

            var result = controller.GetAllPatients();

            Assert.IsType<Task<ActionResult<IEnumerable<Patient>>>>(result);
        }

        [Fact]
        public void GetPatient_RetrievesIntendedPatient()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);
            int intended_id = 1;

            var result = controller.GetPatient(intended_id);

            Assert.IsType<Task<ActionResult<Patient>>>(result);
        }

        [Fact]
        public void PutPatient_UpdatesGivenPatient()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);
            Patient updatedPat = new Patient();
            updatedPat.patient_id = 1;
            updatedPat.name = "";

            var result = controller.PutPatient(updatedPat.patient_id, updatedPat);

            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void ResetPassword_ResetsGivenPatientsPassword()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);
            Patient updatedPat = new Patient();
            updatedPat.patient_id = 1;
            updatedPat.password = "";

            var result = controller.resetPasssword(updatedPat.patient_id, updatedPat);

            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void PostPatient_CreatesNewPatient()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);
            Patient newPat = new Patient();

            var result = controller.PostPatient(newPat);

            Assert.IsType<Task<ActionResult<Patient>>>(result);
        }

        [Fact]
        public void LogInPatient_LogsInGivenPatient()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);
            Patient givenPat = new Patient();
            givenPat.email = "test1";
            givenPat.password = "salt";

            var result = controller.LogInPatient(givenPat);

            Assert.IsType<ActionResult<Patient>>(result);
        }

        [Fact]
        public void UpdateProfile_UpdatesGivenUserProfile()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Patients.AsQueryable()).Returns(new MockPatientSet());
            var controller = new PatientController(mock.Object);
            Patient updatedPat = new Patient();
            updatedPat.patient_id = 1;
            updatedPat.name = "";

            var result = controller.updateProfile(updatedPat.patient_id, updatedPat);

            Assert.IsType<Task<ActionResult<Patient>>>(result);
        }
    }
}
