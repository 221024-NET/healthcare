using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly Context _context;

    public PatientController(Context context)
    {
        _context = context;
    }


    [HttpGet("/paitents")]
    public async Task<ActionResult<IEnumerable<Patient>>> GetTodoItems()
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }
        return await _context.Patients.ToListAsync();
    }

    [HttpGet("/paitents/{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }
        var todoItem = await _context.Patients.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        // return todoItem;
        return todoItem;
    }



    [HttpPut("/paitents")]
    public async Task<IActionResult> PutInsuranceClaim(int id, Patient patient)
    {
        if (id != patient.patient_id)
        {
            return BadRequest();
        }

        _context.Entry(patient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PatientExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();

    }

    [HttpPost("/paitents")]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        if (_context.Patients == null)
        {
            return Problem("Entity set 'Context.Patients'  is null.");
        }

        //Encrypt password here


        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPatient), new { id = patient.patient_id }, patient);
    }

//<<<<<<< HEAD
   

//=======
    [HttpPost("paitents/LogIn")]
    public ActionResult<Patient> LogInPatient(Patient patient)
    {
        if (patient == null)
        {
            return BadRequest();
        }

        var t = _context.Patients.Where(pt => pt.email == patient.email && pt.password == patient.password).FirstOrDefault();
        if (t == null)
        {
            return BadRequest();
        }
        return t;
    }
//>>>>>>> 7036e1a0fa0539305f56c54cb0f25fa9778db0fc

    private bool PatientExists(int id)
    {
        return (_context.Patients?.Any(e => e.patient_id == id)).GetValueOrDefault();
    }

}
