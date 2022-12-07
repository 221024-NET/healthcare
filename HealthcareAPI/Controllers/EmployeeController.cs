using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly Context _context;

        public EmployeeController(Context context)
        {
            _context = context;
        }

        [HttpGet("/employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost("/employee")]
        public async Task<ActionResult<Employee>> CreateNewEmployee(Employee employee)
        {
           if(employee == null)
            {
                return BadRequest();
            }
           if(EmployeeExists(employee.employee_id))
            {
                return BadRequest(); 
            }

           //Encrypt password here
            
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.employee_id }, employee);
        }
        [HttpPost ("/employee/LogIn")]
        public ActionResult<Employee> LogInEmployee(Employee employee) 
        {
            if (employee == null) {
                return BadRequest();
            }

            var t= _context.Employees.Where(em => em.email == employee.email && em.password == employee.password).FirstOrDefault();
            if (t == null) {
                return BadRequest();
            }
            return t;
        }

        [HttpDelete("/employee/{id}")]
        public async Task<IActionResult> DeleteEmployee (int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.employee_id == id)).GetValueOrDefault();
        }


    }
}
