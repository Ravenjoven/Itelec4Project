
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Department { get; set; }
    public DbSet<Employee> Employee { get; set; }
}
