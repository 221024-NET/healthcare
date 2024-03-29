using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;
using System.Security.Cryptography;

namespace HealthcareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IContext _context;

    public PatientController(IContext context)
    {
        _context = context;
    }


    [HttpGet("/patients")]
    public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }
        return await _context.Patients.ToListAsync();
    }

    [HttpGet("/patients/{id}")]
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



    //[HttpPut("/patients")]
    //public async Task<IActionResult> PutPatient(int id, Patient patient)
    //{
    //    if (id != patient.patient_id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.DenotePatientModified(patient);

    //    try
    //    {
    //        await _context.CommitChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!PatientExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }
    //    return NoContent();

    //}

    [HttpPut("/patients/newPassword/{id}")]
    public async Task<IActionResult> resetPasssword(int id, Patient patient)
    {
        if (id != patient.patient_id)
        {
            return BadRequest();
        }

        //patient.password = EncryptPwd(patient.password);

        _context.DenotePatientModified(patient);

        try
        {
            await _context.CommitChangesAsync();
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

    [HttpPost("/patients")]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        if (_context.Patients == null)
        {
            return Problem("Entity set 'Context.Patients'  is null.");
        }

        //Encrypt password here
        //patient.password = EncryptPwd(patient.password);


        _context.Patients.Add(patient);
        await _context.CommitChangesAsync();

        return CreatedAtAction(nameof(GetPatient), new { id = patient.patient_id }, patient);
    }

    [HttpPost("/patients/LogIn")]
    public ActionResult<Patient> LogInPatient(Patient patient)
    {
        if (patient == null)
        {
            return BadRequest();
        }
        //patient.password = EncryptPwd(patient.password);
        var t = _context.Patients.Where(pt => pt.email == patient.email && pt.password == patient.password).FirstOrDefault();
        if (t == null)
        {
            return BadRequest();
        }
        return t;
    }

    //[HttpPut("/patients/updateProfile/{id}")]
    //public async Task<ActionResult<Patient>> updateProfile(int id, Patient patient)
    //{
        

    //    if (id != patient.patient_id)
    //    {
    //        return BadRequest();
    //    }
    //    _context.DenotePatientModified(patient);

    //    try
    //    {
    //        await _context.CommitChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!PatientExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }
    //    return patient;

    //}

    private bool PatientExists(int id)
    {
        return (_context.Patients?.Any(e => e.patient_id == id)).GetValueOrDefault();
    }

    //private string EncryptPwd(string password)
    //{
    //    SHA256 myHash = SHA256.Create();
    //    string salt = "wim";
    //    string combined = salt + password;

    //    byte[] bytes = new byte[combined.Length * sizeof(char)];
    //    System.Buffer.BlockCopy(combined.ToCharArray(), 0, bytes, 0, bytes.Length);

    //    byte[] hashvalue = myHash.ComputeHash(bytes);
    //    string hash = BitConverter.ToString(hashvalue).Replace("-", "");

    //    return hash;
    //}

}
