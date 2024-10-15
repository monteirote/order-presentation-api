using System;
using System.ComponentModel.DataAnnotations;


namespace OrderPresentationApi.Models {

    public class Usuario {

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Salt { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public UserRole Role { get; set; }
    }
}
