using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPresentationApi.Models.DTOs {
    public class TipoMaterialDTO {

        public TipoMaterialDTO (TipoMaterial tipoMaterial) {
            Id = tipoMaterial.Id;
            Nome = tipoMaterial.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
