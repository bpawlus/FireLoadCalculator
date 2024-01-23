using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FireLoadCalculator.Models
{
    public class Material
    {
        public Material() { }

        public Material(string _name, float _combustionheat, float _reductionfactor) { 
            Name = _name;
            CombustionHeat = _combustionheat;
            ReductionFactor = _reductionfactor;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public float CombustionHeat { get; set; }
        public float ReductionFactor { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
        public List<RoomMaterials> RoomMaterials { get; set; }
    }
}
