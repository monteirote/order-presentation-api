namespace OrderPresentationApi.Models.DTOs
{
    public class MaterialDTO
    {
        public MaterialDTO (Material material) {
            Id = material.Id;
            Name = material.Name;
            IdTipoMaterial = material.IdTipoMaterial;
            TipoMaterial = material.TipoMaterial.Nome;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTipoMaterial { get; set; }
        public string TipoMaterial { get; set; }
    }
}
