using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CorreoController : ControllerBase
    {      
        [HttpPost("enviar")]
        public void Post([FromBody] string value)
        {
        }       
    }
}
