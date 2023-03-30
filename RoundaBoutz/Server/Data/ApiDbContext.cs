using Microsoft.EntityFrameworkCore;

namespace RoundaBoutz.Server.Data;

public class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {

    }

}