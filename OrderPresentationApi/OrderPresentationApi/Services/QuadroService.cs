using OrderPresentationApi.Models;
using OrderPresentationApi.Repositories;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Services {

    public interface IQuadroService {

    }

    public class QuadroService : IQuadroService {

        private readonly IQuadroRepository _quadroRepository;

        public QuadroService (IQuadroRepository quadroRepository) {
            _quadroRepository = quadroRepository;
        }

        public async Task<Quadro> FindById (int id) {
            return await _quadroRepository.GetByIdAsync(id);
        }

        public async Task<List<Quadro>> FindAll() {
            return await _quadroRepository.GetAllAsync();
        }

        public async Task<Quadro> Create (QuadroViewModel quadro) {
            var novoQuadro = new Quadro(quadro);
            await _quadroRepository.CreateAsync(novoQuadro);

            return novoQuadro;
        }

        public async Task<bool> Update (int id, QuadroViewModel quadro) {
            var quadroEncontrado = await _quadroRepository.GetByIdAsync(id);

            if (quadroEncontrado is null)
                return false;

            // fazer alterações no quadro do banco

            await _quadroRepository.UpdateAsync(quadroEncontrado);

            return true;
        }

        public async Task<bool> Delete (int id) {
            var quadroEncontrado = await _quadroRepository.GetByIdAsync(id);

            if (quadroEncontrado is null)
                return false;

            await _quadroRepository.DeleteAsync(quadroEncontrado);

            return true;
        }
    }
}
