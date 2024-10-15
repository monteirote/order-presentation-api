using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPresentationApi.ViewModels {
    public class LoginUsuarioViewModel {

        [Required(ErrorMessage = "Preencha o campo nome de usuário.")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo senha.")]
        public string Senha { get; set; }

    }
}
