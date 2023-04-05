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

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerDetails(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (customer == null)
         {
            return NotFound();
         }   

        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomerDetails), customer, customer.Id);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateCustomer(Customer customer, Guid id)
    {
        var customerCheck = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if(customerCheck == null)
        {
            return NotFound();
        }

        customerCheck.FirstName   = customer.FirstName;
        customerCheck.LastName    = customer.LastName;
        customerCheck.PhoneNumber = customer.PhoneNumber;
        customerCheck.Active      = customer.Active;

        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customerCheck = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (customerCheck == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customerCheck);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
