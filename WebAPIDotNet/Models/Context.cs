using Microsoft.EntityFrameworkCore;

namespace WebAPIDotNet.Models
{
  public class Context : DbContext
  {
    //DbSets
    public DbSet<Department> Department { get; set; }
    public DbSet<Employee> Employee { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
  }
}
