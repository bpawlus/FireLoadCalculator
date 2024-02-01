using CommunityToolkit.Mvvm.ComponentModel;
using FireLoadCalculator.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace FireLoadCalculator.Models
{
    public partial class Room
    {
        public Room() { }

        public Room(RoomViewModel vm)
        {
            Id = vm.Id ?? 0;
            Name = vm.Name ?? "";
            Area = vm.Area ?? 0.0;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public double Area { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeDelete)]
        public List<RoomMaterial> RoomMaterials { get; set; }
    }
}
