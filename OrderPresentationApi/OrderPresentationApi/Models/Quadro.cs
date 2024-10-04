using OrderPresentationApi.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace OrderPresentationApi.Models {

    public class Quadro {

        [Key]
        public int ID { get; set; }

        [Required]
        public int ID_ORDEM_SERVICO { get; set; }

        public int VL_ALTURA { get; set; }

        public int VL_LARGURA { get; set; }

        public int CD_MOLDURA { get; set; }

        public int CD_IMPRESSAO { get; set; }

        public int CD_VIDRO { get; set; }

        public int CD_FUNDO { get; set; }

        public Quadro () { }

        public Quadro (QuadroViewModel quadro) { 
            
        }
    }
}
