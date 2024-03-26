using WebApiGerenciador.DataContext;
using WebApiGerenciador.Models;

namespace WebApiGerenciador.Services.PontoServices
{

    public class PontoService : IPontoInterface
    {
        private readonly AplicationDbContext _context;

        public PontoService(AplicationDbContext context) {
        
            _context = context;
        }


        public async Task<ServiceResponse<List<PontoModel>>> CreatePonto(PontoModel novoPonto)
        {
            ServiceResponse<List<PontoModel>> serviceResponse = new ServiceResponse<List<PontoModel>>();    
            try {

                if (novoPonto == null) {

                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;

                }

                _context.Add(novoPonto);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Ponto.ToList();
                
            }catch (Exception ex) { 
            
                serviceResponse.Mensagem = ex.Message; 
                serviceResponse.Sucesso = false; 
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<PontoModel>>> DeletePonto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PontoModel>>> GetPontos()
        {
            ServiceResponse<List<PontoModel>> serviceResponse = new ServiceResponse<List<PontoModel>>();
        
            try
            {

                serviceResponse.Dados = _context.Ponto.ToList();
                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }

            }catch  (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<PontoModel>> GetPontoById(int id)
        {
            throw new NotImplementedException();
        }


        public Task<ServiceResponse<List<PontoModel>>> UpdatePonto(PontoModel editadoPonto)
        {
            throw new NotImplementedException();
        }
    }
}
