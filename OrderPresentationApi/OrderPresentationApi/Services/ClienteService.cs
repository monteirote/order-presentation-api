using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Repositories;
using OrderPresentationApi.Models;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Services
{
    public interface IClienteService {
        Task<Cliente> GetById (int id);
        Task<List<Cliente>> GetAll ();
        Task<Cliente> CreateCliente (ClienteViewModel cliente);
        Task<bool> UpdateCliente (int id, ClienteViewModel cliente);
        Task<bool> DeleteCliente (int id);
    }

    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ClienteService : IClienteService {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService (IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }


        public async Task<Cliente> GetById (int id) {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<List<Cliente>> GetAll () {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> CreateCliente (ClienteViewModel cliente) {
            var novoCliente = new Cliente(cliente);
            await _clienteRepository.CreateAsync(novoCliente);

            return novoCliente;
        }

        public async Task<bool> UpdateCliente (int id, ClienteViewModel cliente) {
            var clienteEncontrado = await _clienteRepository.GetByIdAsync(id);

            if (clienteEncontrado == null)
                return false;

            clienteEncontrado.Name = cliente.Name;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Email = cliente.Email;

            await _clienteRepository.UpdateAsync(clienteEncontrado);

            return true;
        }
        
        public async Task<bool> DeleteCliente (int id) {
            var clienteEncontrado = await _clienteRepository.GetByIdAsync(id);

            if (clienteEncontrado == null)
                return false;

            await _clienteRepository.DeleteAsync(clienteEncontrado);

            return true;
        }
    }
}
