using System;
using System.ComponentModel.DataAnnotations;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Models
{
    public class Cliente {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public Cliente (ClienteViewModel cliente)
        {
            Name = cliente.Name;
            Telefone = cliente.Telefone;
            Email = cliente.Email;
        }

        public Cliente () { }
    }
}
