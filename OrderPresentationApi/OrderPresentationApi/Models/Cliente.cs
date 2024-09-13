using System;
using System.ComponentModel.DataAnnotations;

namespace OrderPresentationApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
