namespace FireLoadCalculator.Models
{
    internal class Room
    {
        public float Area { get; set; }
        public Material? StoredMaterial { get; set; }
        public float StoredMaterialWeight { get; set; }
        public uint StoredMaterialCount { get; set; }
    }
}
