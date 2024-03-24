using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGerenciador.Models;
using WebApiGerenciador.Services.ColaboradorServices;

namespace WebApiGerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorInterface _colaboradorInterface;
        public ColaboradorController(IColaboradorInterface colaboradorInterface)
        {
            _colaboradorInterface = colaboradorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ColaboradoresModel>>>> GetColaboradores()
        {

            return Ok( await _colaboradorInterface.GetColaboradores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ColaboradoresModel>>> GetColaboradorById(int id)
        {
            ServiceResponse<ColaboradoresModel> serviceResponse = await _colaboradorInterface.GetColaboradorById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ColaboradoresModel>>>> CreateColaborado(ColaboradoresModel novoColaborador)
        {
            return Ok( await _colaboradorInterface.CreateColaborador(novoColaborador));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ColaboradoresModel>>>> UpdateColaborador(ColaboradoresModel editadoColaborador)
        {
            ServiceResponse<List<ColaboradoresModel>> serviceResponse = await _colaboradorInterface.UpdateColaborador(editadoColaborador);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ColaboradoresModel>>>> DeleteColaborador(int id)
        {
            ServiceResponse<List<ColaboradoresModel>> serviceResponse = await _colaboradorInterface.DeleteColaborador(id);

            return Ok(serviceResponse);
        }

    }
}
