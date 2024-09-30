using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPresentationApi.ViewModels {
    public class OrdemServicoViewModel {

        [Required(ErrorMessage = "O código da OS é obrigatório")]
        public string DsCodigo { get; set; }


        [Required(ErrorMessage = "A data de entrega é obrigatória")]
        public DateTime DataEntrega { get; set; }


        [Required(ErrorMessage = "O cliente é obrigatório")]
        public int CdCliente { get; set; }

        public string DsObservacao { get; set; }
    }
}
