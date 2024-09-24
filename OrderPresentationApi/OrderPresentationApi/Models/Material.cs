using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OrderPresentationApi.ViewModels;


namespace OrderPresentationApi.Models
{
    public class Material {
        public Material () { }

        public Material (MaterialViewModel material) {
            Name = material.Nome;
            IdTipoMaterial = material.IdTipoMaterial;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int IdTipoMaterial { get; set; }

        public TipoMaterial TipoMaterial { get; set; }
    }
}
