using System.ComponentModel.DataAnnotations;

namespace OrderPresentationApi.ViewModels {
    public class TipoMaterialViewModel {

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

    }
}
