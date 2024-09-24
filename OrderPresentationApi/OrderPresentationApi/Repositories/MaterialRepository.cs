using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Models.DTOs;
using OrderPresentationApi.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderPresentationApi.Repositories
{
    public interface IMaterialRepository {
        Task<TipoMaterial> GetTipoByIdAsync (int id);
        Task<List<TipoMaterial>> GetAllTiposAsync ();
        Task CreateTipoAsync (TipoMaterial tipoMaterial);
        Task UpdateTipoAsync (TipoMaterial tipoMaterial);
        Task DeleteTipoAsync (TipoMaterial tipoMaterial);
        Task<Material> GetByIdAsync (int id);
        Task<List<Material>> GetAllAsync ();
        Task CreateAsync (Material material);
        Task UpdateAsync(Material material);
        Task DeleteAsync(Material material);
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
        public async Task<Material> GetByIdAsync (int id) {
            return await _context.Materiais.FindAsync(id);
        }

        public async Task<List<Material>> GetAllAsync () {
            var results = await (from m in _context.Materiais
                    join tm in _context.TiposMateriais on m.IdTipoMaterial equals tm.Id
                    select new Material {
                        Id = m.Id,
                        Name = m.Name,
                        TipoMaterial = tm
                    }).ToListAsync();

            return results;
        }

        public async Task CreateAsync (Material material)
        {
            await _context.Materiais.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Material material)
        {
            _context.Materiais.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (Material material)
        {
            _context.Materiais.Remove(material);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
