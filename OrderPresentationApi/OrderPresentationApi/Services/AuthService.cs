using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPresentationApi.Models;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Services {

    public interface IAuthService {
        public Usuario ValidarUsuario (LoginUsuarioViewModel usuario);
    }

    public class AuthService : IAuthService {

        public Usuario ValidarUsuario(LoginUsuarioViewModel usuario) { 
            
        }
    }
}
