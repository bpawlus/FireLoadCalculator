using CommunityToolkit.Mvvm.ComponentModel;
using FireLoadCalculator.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace FireLoadCalculator.Models
{
    public partial class RoomMaterial
    {
        public RoomMaterial() { }

        public RoomMaterial(RoomMaterialViewModel vm)
        {
            Id = vm.Id ?? 0;
            RoomId = vm.RoomId ?? 0;
            MaterialId = vm.SelectedMaterial?.Id ?? 0;
            MaterialWeight = vm.MaterialWeight ?? 0;
            MaterialCount = vm.MaterialCount ?? 0;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Room))]
        public int RoomId { get; set; }

        [ForeignKey(typeof(Material))]
        public int MaterialId { get; set; }

        public float MaterialWeight { get; set; }

        public uint MaterialCount { get; set; }

    }
}
