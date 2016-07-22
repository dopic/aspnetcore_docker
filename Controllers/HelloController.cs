
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApplication.Controllers
{
    [Route("api/[controller]")]
    public class HelloController: ControllerBase
    {
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return new JsonResult(new 
            {
                message = $"Hello {name}!"    
            });
        }
    }
}