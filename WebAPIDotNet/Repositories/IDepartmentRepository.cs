using WebAPIDotNet.Models;

namespace WebAPIDotNet.Repositories
{
  public interface IDepartmentRepository
  {
    public List<Department> DisplayAllDepts();
    public Department GetById(int id);
    public Department GetByName(string name);
    public void AddDept(Department dept);
    public bool EditDept(Department dept);
    public void Save();
  }
}
