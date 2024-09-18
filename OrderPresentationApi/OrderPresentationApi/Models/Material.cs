using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPresentationApi.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int IdTipoMaterial { get; set; }

        public TipoMaterial TipoMaterial { get; set; }
    }
}
