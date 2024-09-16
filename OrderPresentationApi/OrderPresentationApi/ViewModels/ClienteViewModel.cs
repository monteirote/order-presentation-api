using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderPresentationApi.ViewModels
{
    public class ClienteViewModel
    {
        [Required (ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }


        [Required (ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O telefone deve estar no formato (00) 0000-0000.")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "O e-mail deve estar no formato correto.")]
        public string Email { get; set; }
    }
}
