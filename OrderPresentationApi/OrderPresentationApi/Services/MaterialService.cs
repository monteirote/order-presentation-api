using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;

namespace OrderPresentationApi.Repositories
{
    public interface IMaterialService {
        Task<TipoMaterial> GetTipoByIdAsync(int id);
        Task<List<TipoMaterial>> GetTiposAsync();
        Task CreateTipoAsync(TipoMaterial tipoMaterial);
        Task UpdateTipoAsync(TipoMaterial tipoMaterial);
        Task DeleteTipoAsync(TipoMaterial tipoMaterial);
        Task<Material> GetByIdAsync(int id);
        Task<List<Material>> GetAllAsync();
        Task CreateAsync(Material material);
        Task UpdateAsync(Material material);
        Task DeleteAsync(Material material);
    }

    public class MaterialService : IMaterialService {

        private readonly IMaterialRepository _materialRepository;

        public MaterialService (IMaterialRepository materialRepository) {
            _materialRepository = materialRepository;
        }


        public async Task<TipoMaterial> GetTipoByIdAsync(int id) {
            return await _materialRepository.GetTipoByIdAsync(id);
        }

        public async Task<List<TipoMaterial>> GetTiposAsync () {
            return await _materialRepository.GetAllTiposAsync();
        }

        public async Task CreateTipoAsync (TipoMaterial tipoMaterial) {
            await _materialRepository.CreateTipoAsync(tipoMaterial);
        }

        public async Task UpdateTipoAsync (TipoMaterial tipoMaterial) {
            await _materialRepository.UpdateTipoAsync(tipoMaterial);
        }

        public async Task DeleteTipoAsync (TipoMaterial tipoMaterial) {
            await _materialRepository.DeleteTipoAsync(tipoMaterial);
        }


        public async Task<Material> GetByIdAsync (int id) {
            return await _materialRepository.GetByIdAsync(id);
        }

        public async Task<List<Material>> GetAllAsync () {
            return await _materialRepository.GetAllAsync();
        }

        public async Task CreateAsync (Material material) {
            await _materialRepository.CreateAsync(material);
        }

        public async Task UpdateAsync (Material material) {
            await _materialRepository.UpdateAsync(material);
        }

        public async Task DeleteAsync (Material material) {
            await _materialRepository.DeleteAsync(material);
        }
    }
}
