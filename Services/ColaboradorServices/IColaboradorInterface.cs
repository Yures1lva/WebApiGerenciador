using WebApiGerenciador.Models;

namespace WebApiGerenciador.Services.ColaboradorServices
{
    public interface IColaboradorInterface
    {
        Task<ServiceResponse<List<ColaboradoresModel>>> GetColaboradores();
        Task<ServiceResponse<List<ColaboradoresModel>>> CreateColaborador(ColaboradoresModel novoColaborador);
        Task<ServiceResponse<ColaboradoresModel>> GetColaboradorById(int Id);
        Task<ServiceResponse<List<ColaboradoresModel>>> UpdateColaborador(ColaboradoresModel EditadoColaborador);
        Task<ServiceResponse<List<ColaboradoresModel>>> DeleteColaborador(int id);
    }
}
