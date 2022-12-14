using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsuranceClaimController : ControllerBase
{
    private readonly IContext _context;

    public InsuranceClaimController(IContext context)
    {
        _context = context;
    }


    [HttpGet("/claims")]
    public async Task<ActionResult<IEnumerable<InsuranceClaim>>> GetAllClaims()
    {
        if (_context.Claims == null)
        {
            return NotFound();
        }
        return await _context.Claims.ToListAsync();
    }

    [HttpGet("/claim/{id}")]
    public async Task<ActionResult<InsuranceClaim>> GetClaim(int id)
    {
        if (_context.Claims == null)
        {
            return NotFound();
        }
        var todoItem = await _context.Claims.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        // return todoItem;
        return todoItem;
    }



    [HttpPut("/claim")]
    public async Task<IActionResult> PutInsuranceClaim( InsuranceClaim insClaim)
    {
        if (_context.Claims ==null)
        {
            return BadRequest();
        }

        _context.Claims.Entry(insClaim).State = EntityState.Modified;

        try
        {
            await _context.CommitChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClaimExists(insClaim.id))
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

    [HttpPost("/claim/new")]
    public async Task<ActionResult<InsuranceClaim>> PostInsuranceClaim(InsuranceClaim newClaim)
    {
        if (_context.Claims == null)
        {
            return Problem("Entity set 'Context.Claims' is null.");
        }
        _context.Claims.Add(newClaim);
        await _context.CommitChangesAsync();

        return CreatedAtAction(nameof(GetClaim), new { id = newClaim.id }, newClaim);
    }

    private bool ClaimExists(int id)
    {
        return (_context.Claims?.Any(e => e.id == id)).GetValueOrDefault();
    }

}
