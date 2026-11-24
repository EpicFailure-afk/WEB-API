using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDotNet.Models;

namespace WebAPIDotNet.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BindingController : ControllerBase
  {
    [HttpGet("{name:alpha}/{age:int}")]
    public IActionResult testPrimitive(int age, string? name)
    {
      return Ok();
    }


    [HttpPost]
    public IActionResult TestObj(Department dept, string? name)
    {
      return Ok();
    }
    /*
      - Complex objects like Department --> in req body
      - premitive like (string, int, etc) --> in url
      and you can customize what you want 
    */

    //! customize Binding
    // [FromRoute] will search in the url (before '?')
    [HttpGet("{id}/{name}/{ManagerName}")]
    public IActionResult TestCustumBind([FromRoute] Department dept)
    {
      return Ok();
    }
  }
}
