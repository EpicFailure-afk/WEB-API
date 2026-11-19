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

    //EndPoints

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

    [HttpGet("{Name:alpha}")]
    public IActionResult GetByName(string name)
    {
      Department deptName = deptRepo.GetByName(name);
      return Ok(deptName);
    }

    //api/Department Post
    [HttpPost]
    public IActionResult AddDept(Department dept)
    {
      deptRepo.AddDept(dept);
      deptRepo.Save();
      return CreatedAtAction("GetById", new {id = dept.Id} ,dept);
    }

    [HttpPut("{id:int}")]
    public IActionResult EditDept(int id, Department dept)
    {
      if (id != dept.Id)
        return BadRequest();
      bool req = deptRepo.EditDept(dept);
      if (req == false)
      {
        return NotFound();
      }
      deptRepo.Save();
      return NoContent();
    }
  }
}
