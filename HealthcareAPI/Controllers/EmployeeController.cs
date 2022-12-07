using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;
using System.Security.Cryptography;

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

            employee.password = EncryptPwd(employee.password);
            
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

        private string EncryptPwd(string password)
        {
            SHA256 myHash = SHA256.Create();
            string salt = "wim";
            string combined = salt + password;

            byte[] bytes = new byte[combined.Length * sizeof(char)];
            System.Buffer.BlockCopy(combined.ToCharArray(), 0, bytes, 0, bytes.Length);

            byte[] hashvalue = myHash.ComputeHash(bytes);
            string hash = BitConverter.ToString(hashvalue).Replace("-", "");

            return hash;
        }


    }
}
