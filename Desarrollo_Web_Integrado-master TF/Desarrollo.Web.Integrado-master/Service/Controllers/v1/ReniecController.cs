using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Reflection;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReniecController : ControllerBase
    {
        private readonly ReniecService _reniecService;

        public ReniecController(ReniecService reniecService)
        {
            _reniecService = reniecService;
        }

        [HttpGet("dni")]
        public async Task<ActionResult<ReniecService.Persona>> Get(int numero)
        {
            var persona = await _reniecService.ConsumirServicioAsync(numero);
            if (persona == null)
                return NotFound($"No hay persona con dni {numero}");

            return persona;
        }
    }
}
