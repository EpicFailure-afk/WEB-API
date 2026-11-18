using Microsoft.EntityFrameworkCore;

namespace WebAPIDotNet.Models
{
  public class Context : DbContext
  {
    public DbSet<Department> Department { get; set; }
    public Context(DbContextOptions<Context> options) : base(options)
    {
      
    }
  }
}
