using Microsoft.AspNetCore.Mvc;
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

    public void Save()
    {
      context.SaveChanges();
    }

    public Department GetById(int id)
    {
      Department dept = context.Department.FirstOrDefault(d => d.Id == id);
      return dept;
    }

    public Department GetByName(string name)
    {
      Department deptName = context.Department.FirstOrDefault(n => n.Name == name);
      return deptName;
    }

    public bool EditDept(Department deptFromRq)
    {
      var deptFromDb = context.Department.FirstOrDefault(d => d.Id == deptFromRq.Id);
      if (deptFromDb == null)
      {
        return false;
      }
      deptFromDb.Name = deptFromRq.Name;
      deptFromDb.ManagerName = deptFromRq.ManagerName;
      return true;
    }
  }
}
