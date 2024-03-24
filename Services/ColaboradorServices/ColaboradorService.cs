using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiGerenciador.DataContext;
using WebApiGerenciador.Models;

namespace WebApiGerenciador.Services.ColaboradorServices
{

    public class ColaboradorService : IColaboradorInterface
    {
        private readonly AplicationDbContext _context;

        public ColaboradorService(AplicationDbContext context) { 
            _context = context;
        }
        public async Task<ServiceResponse<List<ColaboradoresModel>>> CreateColaborador(ColaboradoresModel novoColaborador)
        {
            ServiceResponse<List<ColaboradoresModel>> serviceResponse = new ServiceResponse<List<ColaboradoresModel>>();

            try {

                if(novoColaborador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoColaborador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Colaboradores.ToList();

            }catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ColaboradoresModel>>> DeleteColaborador(int id)
        {
            ServiceResponse<List<ColaboradoresModel>> serviceResponse = new ServiceResponse<List<ColaboradoresModel>>();

            try {
            
                ColaboradoresModel colaborador = _context.Colaboradores.FirstOrDefault(x => x.Id == id);

                if (colaborador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Colaboradores.Remove(colaborador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Colaboradores.ToList();

            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ColaboradoresModel>> GetColaboradorById(int Id)
        {
            
            ServiceResponse<ColaboradoresModel> serviceResponse = new ServiceResponse<ColaboradoresModel>();

            try {

                ColaboradoresModel colaborador = _context.Colaboradores.FirstOrDefault(x => x.Id == Id);

                if(colaborador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso= false;

                }

                serviceResponse.Dados = colaborador;

            }
            catch (Exception ex) {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ColaboradoresModel>>> GetColaboradores()
        {
            ServiceResponse<List<ColaboradoresModel>> serviceResponse = new ServiceResponse<List<ColaboradoresModel>>();

            try
            {
                serviceResponse.Dados = _context.Colaboradores.ToList();
                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ColaboradoresModel>>> UpdateColaborador(ColaboradoresModel editadoColaborador)
        {
            ServiceResponse<List<ColaboradoresModel>> serviceResponse = new ServiceResponse<List<ColaboradoresModel>>();

            try { 
                
                ColaboradoresModel colaborador = _context.Colaboradores.AsNoTracking().FirstOrDefault(x => x.Id == editadoColaborador.Id);

                if(colaborador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Colaboradores.Update(editadoColaborador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Colaboradores.ToList();

            } catch(Exception ex) {

                serviceResponse.Dados = null;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }
    }
}
