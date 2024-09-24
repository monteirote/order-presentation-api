namespace OrderPresentationApi.Models.DTOs
{
    public class MaterialDTO
    {
        public MaterialDTO () { }

        public MaterialDTO (Material material) {
            Id = material.Id;
            Name = material.Name;
            TipoMaterial = new TipoMaterialDTO(material.TipoMaterial);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TipoMaterialDTO TipoMaterial { get; set; }
    }
}
