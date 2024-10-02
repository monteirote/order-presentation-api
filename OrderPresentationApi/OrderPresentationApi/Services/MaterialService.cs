using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Models.DTOs;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Repositories
{
    public interface IMaterialService {

        Task<TipoMaterial> GetTipoByIdAsync(int id);
        Task<List<TipoMaterial>> GetTiposAsync();
        Task<TipoMaterial> CreateTipoAsync (TipoMaterialViewModel tipoMaterial);
        Task<bool> UpdateTipoAsync (int id, TipoMaterialViewModel tipoMaterial);
        Task<bool> DeleteTipoAsync (int id);

        Task<Material> GetByIdAsync(int id);
        Task<List<MaterialDTO>> GetAllAsync();
        Task<MaterialDTO> CreateAsync (MaterialViewModel material);
        Task<bool> UpdateAsync (int id, MaterialViewModel material);
        Task<bool> DeleteAsync (int id);

    }

    public class MaterialService : IMaterialService {

        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository) => _materialRepository = materialRepository;

        #region Funções TiposMaterial

        public async Task<TipoMaterial> GetTipoByIdAsync(int id) {
            return await _materialRepository.GetTipoByIdAsync(id);
        }

        public async Task<List<TipoMaterial>> GetTiposAsync () {
            return await _materialRepository.GetAllTiposAsync();
        }

        public async Task<TipoMaterial> CreateTipoAsync(TipoMaterialViewModel tipoMaterial) {
            var novoTipo = new TipoMaterial(tipoMaterial);
            await _materialRepository.CreateTipoAsync(novoTipo);

            return novoTipo;
        }

        public async Task<bool> UpdateTipoAsync (int id, TipoMaterialViewModel tipoMaterial) {
            var tipoEncontrado = await _materialRepository.GetTipoByIdAsync(id);

            if (tipoEncontrado is null)
                return false;

            tipoEncontrado.Nome = tipoMaterial.Nome;

            await _materialRepository.UpdateTipoAsync(tipoEncontrado);

            return true;
        }

        public async Task<bool> DeleteTipoAsync (int id) {
            var tipoEncontrado = await _materialRepository.GetTipoByIdAsync(id);

            if (tipoEncontrado is null)
                return false;

            await _materialRepository.DeleteTipoAsync(tipoEncontrado);

            return true;
        }

        #endregion

        #region Funções Material
        public async Task<Material> GetByIdAsync (int id) {
            return await _materialRepository.GetByIdAsync(id);
        }

        public async Task<List<MaterialDTO>> GetAllAsync () {
            List<Material> materiais = await _materialRepository.GetAllAsync();

            return (from m in materiais select new MaterialDTO(m)).ToList();
        }

        public async Task<MaterialDTO> CreateAsync (MaterialViewModel material) {
            var novoMaterial = new Material(material);

            var tipoExistente = await _materialRepository.GetTipoByIdAsync(material.IdTipoMaterial);

            if (tipoExistente is null)
                return null;

            await _materialRepository.CreateAsync(novoMaterial);

            return new MaterialDTO(novoMaterial);
        }

        public async Task<bool> UpdateAsync (int id, MaterialViewModel material) {
            var materialEncontrado = await _materialRepository.GetByIdAsync(id);
            var tipoMaterialEncontrado = await _materialRepository.GetTipoByIdAsync(material.IdTipoMaterial);

            if (materialEncontrado is null || tipoMaterialEncontrado is null)
                return false;

            materialEncontrado.Name = material.Nome;
            materialEncontrado.IdTipoMaterial = material.IdTipoMaterial;

            await _materialRepository.UpdateAsync(materialEncontrado);

            return true;
        }

        public async Task<bool> DeleteAsync (int id) {
            var materialEncontrado = await _materialRepository.GetByIdAsync(id);

            if (materialEncontrado is null)
                return false;

            await _materialRepository.DeleteAsync(materialEncontrado);

            return true;
        }
        #endregion
    }
}
