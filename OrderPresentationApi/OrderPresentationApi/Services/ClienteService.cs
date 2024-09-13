using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Repositories;
using OrderPresentationApi.Models;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Services
{
    public interface IClienteService
    {
        Cliente GetCliente(int id);
        ServiceResponse CadastrarCliente(CreateClienteViewModel cliente);
    }

    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente GetCliente(int id)
        {
            return _clienteRepository.GetClienteById(id);
        }

        public ServiceResponse CadastrarCliente(CreateClienteViewModel cliente)
        {
            try
            {
                var novoCliente = new Cliente
                {
                    Name = cliente.Name,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                };

                _clienteRepository.AddCliente(novoCliente);

                return new ServiceResponse { Success = true, Message = "Cliente adicionado com sucesso." };

            } catch (Exception ex)
            {
                string error = "";

                while (ex != null)
                {
                    error += ex.InnerException.Message;
                    ex = ex.InnerException;
                }

                return new ServiceResponse { Success = false, Message = error };
            }
        }
    }
}
