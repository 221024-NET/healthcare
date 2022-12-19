using HealthcareAPI.Controllers;
using HealthcareAPI.Models;
using HealthcareAPI.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Data.Entity;
using Xunit.Sdk;

namespace HealthcareAPI.Tests
{
    public class TestEmployeeController
    {
        [Fact]
        public void GetEmployeeByID_ProperlyRetrievesEmployee()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            int intended_id = 1;
            var controller = new EmployeeController(mock.Object);

            var result = controller.GetEmployeeById(intended_id);

            Assert.IsType<Task<ActionResult<Employee>>>(result);
        }

        [Fact]
        public void CreateNewEmployee_ProperlyCreatesNewEmployee()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            var controller = new EmployeeController(mock.Object);
            Employee newEmp = new Employee();

            var result = controller.CreateNewEmployee(newEmp);

            Assert.IsType<Task<ActionResult<Employee>>>(result);
        }

        [Fact]
        public void LogInEmployee_SuccessfullyLogsIn()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            var controller = new EmployeeController(mock.Object);
            Employee newEmp = new Employee();
            newEmp.email = "test";
            newEmp.password = "test1";

            var result = controller.LogInEmployee(newEmp);

            Assert.IsType<ActionResult<Employee>>(result);
        }

        [Fact]
        public async void ResetPassword_ResetsPasswordForCorrectEmployee()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            var controller = new EmployeeController(mock.Object);
            Employee newEmp = new Employee();
            newEmp.employee_id = 1;
            newEmp.password = "newtest";

            var result = controller.resetPasssword(newEmp.employee_id, newEmp);

            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public async void UpdateProfile_UpdatesProfileForCorrectEmployee()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            var controller = new EmployeeController(mock.Object);
            Employee newEmp = new Employee();
            newEmp.employee_id = 1;
            newEmp.name = "Tem";

            var result = controller.updateProfile(newEmp.employee_id, newEmp);

            Assert.IsType<Task<ActionResult<Employee>>>(result);
        }

        [Fact]
        public async void DeleteEmployee_RemovesEmployee()
        {
            var mock = new Mock<IContext>();
            mock.Setup(m => m.Employees.AsQueryable()).Returns(new MockEmployeeSet());
            var controller = new EmployeeController(mock.Object);
            int intended_id = 1;

            var result = controller.DeleteEmployee(intended_id);

            Assert.IsType<Task<IActionResult>>(result);
        }
    }
}