using Microsoft.EntityFrameworkCore;
using OrderPresentationApi.Data;
using OrderPresentationApi.Models;
using System.Threading.Tasks;

namespace OrderPresentationApi.Repositories {

    public interface IQuadroRepository {
        Task<Quadro> GetByIdAsync (int id);
        Task<List<Quadro>> GetAllAsync ();
        Task CreateAsync (Quadro novoQuadro);
        Task UpdateAsync(Quadro novoQuadro);
        Task DeleteAsync(Quadro novoQuadro);
    }

    public class QuadroRepository : IQuadroRepository {

        private readonly AppDbContext _context;

        public QuadroRepository (AppDbContext context) {
            _context = context;
        }

        public async Task<Quadro> GetByIdAsync (int id) {
            return await _context.Quadros.FindAsync(id);
        }

        public async Task<List<Quadro>> GetAllAsync () {
            return await _context.Quadros.ToListAsync();
        }

        public async Task CreateAsync (Quadro novoQuadro) {
            await _context.Quadros.AddAsync(novoQuadro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Quadro novoQuadro) {
            _context.Quadros.Update(novoQuadro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (Quadro novoQuadro) { 
            _context.Quadros.Remove(novoQuadro);
            await _context.SaveChangesAsync();
        }
    }
}
