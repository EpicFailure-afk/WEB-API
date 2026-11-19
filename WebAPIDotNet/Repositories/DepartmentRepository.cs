using WebAPIDotNet.Models;

namespace WebAPIDotNet.Repositories
{
  public class DepartmentRepository: IDepartmentRepository
  {
    Context context;
    public DepartmentRepository(Context _context)
    {
      context = _context;
    }

    public List<Department> DisplayAllDepts()
    {
      return context.Department.ToList();
    }

    public void AddDept(Department dept)
    {
      context.Add(dept);
    }

    public void EditDept(Department dept)
    {
      context.Department.FirstOrDefault(d => d.Id == dept.Id);
    }

    public void Save()
    {
      context.SaveChanges();
    }

    public Department GetById(int id)
    {
      Department dept = context.Department.FirstOrDefault(d => d.Id == id);
      return dept;
    }
  }
}
