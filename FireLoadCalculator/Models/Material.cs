namespace FireLoadCalculator.Models
{
    public class Material
    {
        public Material(string _name, float _combustionheat, float _reductionfactor) { 
            Name = _name;
            CombustionHeat = _combustionheat;
            ReductionFactor = _reductionfactor;
        }

        public string Name { get; set; }
        public float CombustionHeat { get; set; }
        public float ReductionFactor { get; set; }
    }
}
