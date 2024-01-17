namespace FireLoadCalculator.Models
{
    public class Room
    {
        public string Name { get; set; }
        public float Area { get; set; }
        public Material? StoredMaterial { get; set; }
        public float StoredMaterialWeight { get; set; }
        public uint StoredMaterialCount { get; set; }
    }
}
