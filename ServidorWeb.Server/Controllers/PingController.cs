using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServidorWeb.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpHead]
        public IActionResult Ping() => Ok();
    }

}
