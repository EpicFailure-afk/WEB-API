namespace WebAPIDotNet.Models
{
  public class Department
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ManagerName { get; set; }

    //nav-prop
    public List<Employee> Employees { get; set; }
  }
}
