using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace FireLoadCalculator.Models
{
    public delegate void RoomMaterialsDelegate();

    public partial class RoomMaterials : ObservableObject
    { 
        RoomMaterialsDelegate? cb;

        public RoomMaterials() { }
        public RoomMaterials(int _rid, int _mid, float _weight, uint _count, RoomMaterialsDelegate? _cb)
        {
            RoomId = _rid;
            MaterialId = _mid;
            MaterialWeight = _weight;
            MaterialCount = _count;
            cb = _cb;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Room))]
        public int RoomId { get; set; }

        [ForeignKey(typeof(Material))]
        public int MaterialId { get; set; }
        [ObservableProperty]
        public float materialWeight;
        [ObservableProperty]
        public uint materialCount;

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            string changed = e.PropertyName ?? "";
            Debug.WriteLine($"Changed {changed}");
            if(cb != null) cb();
        }
    }
}
