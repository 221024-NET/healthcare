using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsuranceClaimController : ControllerBase
{
    private readonly Context _context;

    public InsuranceClaimController(Context context)
    {
        _context = context;
    }


    [HttpGet("/claims")]
    public async Task<ActionResult<IEnumerable<InsuranceClaim>>> GetTodoItems()
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
    public async Task<IActionResult> PutInsuranceClaim(int id, InsuranceClaim insClaim)
    {
        if (id != insClaim.id)
        {
            return BadRequest();
        }

        _context.Entry(insClaim).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClaimExists(id))
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


    //What is this one supposed to do? it still has ToDo stuff from copy/pasting
    //[HttpPost]
    //public async Task<ActionResult<InsuranceClaim>> PostTodoItem(InsuranceClaim insClaim)
    //{
    //    if (_context.Claims == null)
    //    {
    //        return Problem("Entity set 'TodoContext.TodoItems'  is null.");
    //    }
    //    _context.Claims.Add(insClaim);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction(nameof(GetClaim), new { id = insClaim.id }, insClaim);
    //}


    private bool ClaimExists(int id)
    {
        return (_context.Claims?.Any(e => e.id == id)).GetValueOrDefault();
    }

}
