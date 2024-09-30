using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Data;

namespace OrderPresentationApi.Repositories {

    public interface IOrdemServicoRepository {
        Task<OrdemServico> GetByIdAsync (int id);
        Task<List<OrdemServico>> GetAllAsync();
        Task CreateAsync (OrdemServico ordemServico);
        Task UpdateAsync (OrdemServico ordemServico);
        Task DeleteAsync (OrdemServico ordemServico);
    }

    public class OrdemServicoRepository : IOrdemServicoRepository {

        private readonly AppDbContext _context;

        public OrdemServicoRepository (AppDbContext context) {
            _context = context;
        }

        public async Task<OrdemServico> GetByIdAsync (int id) {
            return await _context.OrdensServico.FindAsync(id);
        }

        public async Task<List<OrdemServico>> GetAllAsync () {
            return await _context.OrdensServico.ToListAsync();
        }

        public async Task CreateAsync (OrdemServico ordemServico) {
            await _context.OrdensServico.AddAsync(ordemServico);
            await _context.SaveChanges();
        }

        public async Task UpdateAsync (OrdemServico ordemServico) {
            _context.OrdensServico.Update(ordemServico);
            await _context.SaveChanges();
        }

        public async Task DeleteAsync (OrdemServico ordemServico) {
            _context.OrdensServico.Delete(ordemServico);
            await _context.SaveChanges();
        }
    }
}
