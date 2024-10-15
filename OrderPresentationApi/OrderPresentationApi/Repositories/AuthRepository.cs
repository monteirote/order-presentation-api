using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderPresentationApi.Repositories {

    public interface IAuthRepository { 
    
    }

    public class AuthRepository : IAuthRepository {

        private readonly AppDbContext _context;

        public AuthRepository (AppDbContext context)
        {
            _context = context;
        }

        public Usuario BuscarUsuarioByNomeUsuario (string nomeUsuario) {
            var usuarioEncontrado = _context.Usuarios.FirstOrDefault(x => x.NomeUsuario == nomeUsuario);
        }
    }
}
