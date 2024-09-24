using System.ComponentModel.DataAnnotations;

namespace OrderPresentationApi.ViewModels
{
    public class MaterialViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O ID do tipo de material é obrigatório")]
        public int IdTipoMaterial { get; set; }
    }
}
