using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace FireLoadCalculator.Models
{
    public partial class Room : ObservableObject
    {
        public Room() { }
        public Room(string _name, float _area) { 
            Name = _name;
            Area = _area;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public float area;

        [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
        public List<RoomMaterials> RoomMaterials { get; set; }
    }
}
