using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoundaBoutz.Server.Data;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ApiDbContext _context;

    public CustomersController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(customers);
    }
}
