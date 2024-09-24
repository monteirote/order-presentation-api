using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Models
{
    public class TipoMaterial
    {
        public TipoMaterial () { }

        public TipoMaterial (TipoMaterialViewModel tipo) {
            Nome = tipo.Nome;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
