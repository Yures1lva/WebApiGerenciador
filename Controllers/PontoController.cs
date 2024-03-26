using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGerenciador.Models;
using WebApiGerenciador.Services.PontoServices;

namespace WebApiGerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly IPontoInterface _pontoInterface;
        public PontoController(IPontoInterface pontoInterface)
        {
            _pontoInterface = pontoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PontoModel>>>> GetPontos() {
            return Ok( await _pontoInterface.GetPontos());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PontoModel>>>> CreatePonto( PontoModel novoPonto)
        {
            return Ok(await _pontoInterface.CreatePonto(novoPonto));
        }

    }
}
