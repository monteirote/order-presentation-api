using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderPresentationApi.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync (int id);
        Task<List<Cliente>> GetAllAsync ();
        Task CreateAsync (Cliente cliente);
        Task UpdateAsync (Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }

    public class ClienteRepository : IClienteRepository
    {

        private readonly AppDbContext _context;
        public ClienteRepository (AppDbContext context)
        {
            _context = context;
        }


        public async Task<Cliente> GetByIdAsync (int id) {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetAllAsync () {
            return await _context.Clientes.ToListAsync();
        }

        public async Task CreateAsync(Cliente cliente) {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Cliente cliente) {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (Cliente cliente) {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
