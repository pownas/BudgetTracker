using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Core.Models;
using BudgetTracker.Web.Data;

namespace BudgetTracker.Web.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class PaidByController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PaidByController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/PaidBy
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaidBy>>> GetPaidBy()
    {
        return await _context.PaidBy.ToListAsync();
    }

    // GET: api/PaidBy/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PaidBy>> GetPaidBy(Guid id)
    {
        var paidBy = await _context.PaidBy.FindAsync(id);

        if (paidBy == null)
        {
            return NotFound();
        }

        return paidBy;
    }

    // PUT: api/PaidBy/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPaidBy(Guid id, PaidBy paidBy)
    {
        if (id != paidBy.Id)
        {
            return BadRequest();
        }

        _context.Entry(paidBy).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaidByExists(id))
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

    // POST: api/PaidBy
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaidBy>> PostPaidBy(PaidBy paidBy)
    {
        _context.PaidBy.Add(paidBy);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPaidBy", new { id = paidBy.Id }, paidBy);
    }

    // DELETE: api/PaidBy/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePaidBy(Guid id)
    {
        var paidBy = await _context.PaidBy.FindAsync(id);
        if (paidBy == null)
        {
            return NotFound();
        }

        _context.PaidBy.Remove(paidBy);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaidByExists(Guid id)
    {
        return _context.PaidBy.Any(e => e.Id == id);
    }
}
