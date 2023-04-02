using Microsoft.AspNetCore.Mvc;
namespace HelloRestService
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("sayHello")]
        public string SayHello([FromQuery] string name)
        {
            return $"Hello: {name}";
        }
    }
}