using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Data;

namespace OrderPresentationApi.Repositories
{
    public interface IMaterialRepository {
        Task<TipoMaterial> GetTipoByIdAsync (int id);
        Task<List<TipoMaterial>> GetAllTiposAsync ();
    }

    public class MaterialRepository : IMaterialRepository {

        private readonly AppDbContext _context;

        public MaterialRepository (AppDbContext context) {
            _context = context;
        }

        #region Métodos p/ TipoMaterial
        public async Task<TipoMaterial> GetTipoByIdAsync (int id) {
            return await _context.TiposMateriais.FindAsync(id);
        }

        public async Task<List<TipoMaterial>> GetAllTiposAsync () {
            return await _context.TiposMateriais.ToListAsync();
        }

        public async Task CreateTipoAsync(TipoMaterial tipoMaterial)
        {
            await _context.TiposMateriais.AddAsync(tipoMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTipoAsync(TipoMaterial tipoMaterial)
        {
            _context.TiposMateriais.Update(tipoMaterial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTipoAsync(TipoMaterial tipoMaterial)
        {
            _context.TiposMateriais.Remove(tipoMaterial);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Métodos p/ Material
        public async Task<Material> GetByIdAsync(int id)
        {
            return await _context.Materiais.FindAsync(id);
        }

        public async Task<List<Material>> GetAllTsAsync()
        {
            return await _context.Materiais.ToListAsync();
        }

        public async Task CreateAsync(Material material)
        {
            await _context.Materiais.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Material material)
        {
            _context.Materiais.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Material material)
        {
            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
