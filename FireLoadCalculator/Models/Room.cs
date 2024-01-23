using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FireLoadCalculator.Models
{
    public class Room
    {
        public Room() { }
        public Room(string _name, float _area) { 
            Name = _name;
            Area = _area;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Area { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
        public List<RoomMaterials> RoomMaterials { get; set; }
    }
}
