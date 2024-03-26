using WebApiGerenciador.Models;

namespace WebApiGerenciador.Services.PontoServices
{
    public interface IPontoInterface
    {
       

        Task<ServiceResponse<List<PontoModel>>> GetPontos();

        Task<ServiceResponse<List<PontoModel>>> CreatePonto(PontoModel novoPonto);

        Task<ServiceResponse<PontoModel>> GetPontoById(int id);

        Task<ServiceResponse<List<PontoModel>>> UpdatePonto(PontoModel editadoPonto);

        Task<ServiceResponse<List<PontoModel>>> DeletePonto(int id);
        

    }
}
