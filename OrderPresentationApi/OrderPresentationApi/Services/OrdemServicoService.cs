using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Repositories;
using OrderPresentationApi.Models;
using OrderPresentationApi.ViewModels;


namespace OrderPresentationApi.Services {
    public interface IOrdemServicoService {
        Task<OrdemServico> GetById (int id);
        Task<List<OrdemServico>> GetAll ();
        Task<OrdemServico> CreateOrdemServico (OrdemServicoViewModel ordemServico);
        Task<bool> UpdateOrdemServico (int id, OrdemServicoViewModel ordemServico);
        Task<bool> DeleteOrdemServico (int id);
    }

    public class OrdemServicoService : IOrdemServicoService {

        private readonly IOrdemServicoRepository _ordemServicoRepository;

        public OrdemServicoService (IOrdemServicoRepository ordemServicoRepository) {
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<OrdemServico> GetById (int id) {
            return await _ordemServicoRepository.GetByIdAsync(id);
        }

        public async Task<List<OrdemServico>> GetAll () {
            return await _ordemServicoRepository.GetAllAsync();
        }

        public async Task<OrdemServico> CreateOrdemServico (OrdemServicoViewModel ordemServico) {

            var novaOrdemServico = new OrdemServico (ordemServico)
            {
                DtCriacao = DateTime.Now,
                IcCancel = false
            };

            await _ordemServicoRepository.CreateAsync(novaOrdemServico);

            return novaOrdemServico;
        }

        public async Task<bool> UpdateOrdemServico (int id, OrdemServicoViewModel ordemServico) {
            var ordemServicoEncontrada = await _ordemServicoRepository.GetByIdAsync(id);

            if (ordemServicoEncontrada is null)
                return false;

            ordemServicoEncontrada.DtEntrega = ordemServico.DataEntrega;
            ordemServicoEncontrada.DsObservacao = ordemServico.DsObservacao;
            ordemServicoEncontrada.DsCodigoOs = ordemServico.DsCodigo;

            await _ordemServicoRepository.UpdateAsync(ordemServicoEncontrada);

            return true;
        }

        public async Task<bool> DeleteOrdemServico (int id) {
            var ordemServicoEncontrada = await _ordemServicoRepository.GetByIdAsync(id);

            if (ordemServicoEncontrada is null)
                return false;

            await _ordemServicoRepository.DeleteAsync(ordemServicoEncontrada);

            return true;
        }
    }
}
