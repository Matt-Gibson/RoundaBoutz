using Microsoft.EntityFrameworkCore;
using RoundaBoutz.Shared.Models;

namespace RoundaBoutz.Server.Data;

public class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {

    }

    public DbSet<Customer> Customers {get;set;}
    public DbSet<Estimate> Estimates {get;set;}
    
}