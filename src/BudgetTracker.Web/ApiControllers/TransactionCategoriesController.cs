using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Core.Models;
using BudgetTracker.Web.Data;

namespace BudgetTracker.Web.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionCategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TransactionCategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/TransactionCategories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionCategory>>> GetTransactionCategory()
    {
        return await _context.TransactionCategory.ToListAsync();
    }

    // GET: api/TransactionCategories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionCategory>> GetTransactionCategory(Guid id)
    {
        var transactionCategory = await _context.TransactionCategory.FindAsync(id);

        if (transactionCategory == null)
        {
            return NotFound();
        }

        return transactionCategory;
    }

    // PUT: api/TransactionCategories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransactionCategory(Guid id, TransactionCategory transactionCategory)
    {
        if (id != transactionCategory.Id)
        {
            return BadRequest();
        }

        _context.Entry(transactionCategory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TransactionCategoryExists(id))
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

    // POST: api/TransactionCategories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TransactionCategory>> PostTransactionCategory(TransactionCategory transactionCategory)
    {
        _context.TransactionCategory.Add(transactionCategory);
        await _context.SaveChangesAsync();

        return CreatedAtAction($"{nameof(GetTransactionCategory)}", new { id = transactionCategory.Id }, transactionCategory);
    }

    // DELETE: api/TransactionCategories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransactionCategory(Guid id)
    {
        var transactionCategory = await _context.TransactionCategory.FindAsync(id);
        if (transactionCategory == null)
        {
            return NotFound();
        }

        _context.TransactionCategory.Remove(transactionCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TransactionCategoryExists(Guid id)
    {
        return _context.TransactionCategory.Any(e => e.Id == id);
    }
}
