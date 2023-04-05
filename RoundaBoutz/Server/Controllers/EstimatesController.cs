using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoundaBoutz.Server.Data;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstimatesController : ControllerBase
{
    private readonly ApiDbContext _context;

    public EstimatesController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Estimate>>> GetEstimates()
    {
        var estimates = await _context.Estimates.ToListAsync();
        return Ok(estimates);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Estimate>> GetEstimateDetails(Guid id)
    {
        var estimate = await _context.Estimates.FirstOrDefaultAsync(x => x.Id == id);

        if (estimate == null)
         {
            return NotFound();
         }   

        return Ok(estimate);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEstimate(Estimate estimate)
    {
        _context.Estimates.Add(estimate);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEstimateDetails), estimate, estimate.Id);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateEstimate(Estimate estimate, Guid id)
    {
        var estimateCheck = await _context.Estimates.FirstOrDefaultAsync(x => x.Id == id);

        if(estimateCheck == null)
        {
            return NotFound();
        }

        estimateCheck.Customer    = estimate.Customer;
        estimateCheck.IsRush      = estimate.IsRush;
        estimateCheck.DateCreated = estimate.DateCreated;
        estimateCheck.DateUpdated = estimate.DateUpdated;

        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteEstimate(Guid id)
    {
        var estimateCheck = await _context.Estimates.FirstOrDefaultAsync(x => x.Id == id);

        if (estimateCheck == null)
        {
            return NotFound();
        }

        _context.Estimates.Remove(estimateCheck);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
