using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Data;

namespace OrderPresentationApi.Repositories
{
    public interface IClienteRepository
    {
        Cliente GetClienteById(int id);
        void AddCliente(Cliente cliente);
    }

    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository (AppDbContext context)
        {
            _context = context;
        }

        public Cliente GetClienteById (int id)
        {
            return _context.Clientes.Find(id);
        }

        public void AddCliente (Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }
}
