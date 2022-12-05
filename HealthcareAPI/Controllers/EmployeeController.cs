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

        [HttpGet("{id}")]
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

        [HttpPost]
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

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.employee_id == id)).GetValueOrDefault();
        }


    }
}
