using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
//using System.Web.Http;
using WebAPIDotNet.Models;
using WebAPIDotNet.Repositories;

namespace WebAPIDotNet.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentController : ControllerBase
  {
    IDepartmentRepository deptRepo;
    public DepartmentController(IDepartmentRepository _deptRepo)
    {
      deptRepo = _deptRepo;
    }

    //api/Department Get
    [HttpGet]
    public IActionResult DisplayAllDepts()
    {
      List<Department> depts = deptRepo.DisplayAllDepts();
      return Ok(depts);
    }

    [HttpGet]
    [Route("{id:int}")] //api/department/1
    public IActionResult GetById(int id)
    {
      Department dept = deptRepo.GetById(id);
      return Ok(dept);
    }

    //api/Department Post
    [HttpPost]
    public IActionResult AddDept(Department dept)
    {
      deptRepo.AddDept(dept);
      deptRepo.Save();
      return Created($"http://localhost:44345/api/department/{dept.Id}", dept);
    }
    //api/Department Put 
    //[HttpPut]
    //public IActionResult EditDept(Department dept)
    //{

    //}
  }
}
