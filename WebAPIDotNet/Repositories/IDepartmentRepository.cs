using WebAPIDotNet.Models;

namespace WebAPIDotNet.Repositories
{
  public interface IDepartmentRepository
  {
    public List<Department> DisplayAllDepts();
    public void AddDept(Department dept);
    public void EditDept(Department dept);
    public Department GetById(int id);
    public void Save();
  }
}
