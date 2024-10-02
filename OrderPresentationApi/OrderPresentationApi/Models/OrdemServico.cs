using System;
using System.ComponentModel.DataAnnotations;
using OrderPresentationApi.ViewModels;

namespace OrderPresentationApi.Models {
    public class OrdemServico {

        [Key]
        public int Id { get; set; }

        public int CdCliente { get; set; }

        public string DsCodigoOs { get; set; }

        public DateTime DtCriacao { get; set; }

        public DateTime DtEntrega { get; set; }

        public bool IcCancel { get; set; }

        public string DsObservacao { get; set; }

        public OrdemServico (OrdemServicoViewModel ordemServico) {
            this.DsCodigoOs = ordemServico.DsCodigo;
            this.DsObservacao = ordemServico.DsObservacao;
            this.DtEntrega = ordemServico.DataEntrega;
            this.CdCliente = ordemServico.CdCliente;
        }

        public OrdemServico () { }
    }
}
