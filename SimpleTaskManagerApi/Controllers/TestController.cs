using Microsoft.AspNetCore.Mvc;

namespace SimpleTaskManagerApi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello from controllers");

    }
}
