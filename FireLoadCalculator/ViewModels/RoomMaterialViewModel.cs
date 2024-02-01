using CommunityToolkit.Mvvm.ComponentModel;
using FireLoadCalculator.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Channels;
using System.Xml.Linq;

namespace FireLoadCalculator.ViewModels
{
    public delegate void RoomMaterialViewModelDelegate(RoomMaterialViewModel roommaterial);

    public partial class RoomMaterialViewModel : ObservableObject
    {
        RoomMaterialViewModelDelegate? cb;

        public RoomMaterialViewModel() { }

        public RoomMaterialViewModel(RoomMaterial item, Material _selectedMaterial, RoomMaterialViewModelDelegate? _cb)
        {
            Id = item.Id;
            RoomId = item.RoomId;
            SelectedMaterial = _selectedMaterial;
            MaterialWeight = item.MaterialWeight;
            MaterialCount = item.MaterialCount;
            cb = _cb;
        }

        public RoomMaterialViewModel(RoomMaterialViewModelDelegate? _cb)
        {
            cb = _cb;
        }

        [ObservableProperty]
        public int? id;
        [ObservableProperty]
        public int? roomId;

        [ObservableProperty]
        public float? materialWeight;
        [ObservableProperty]
        public uint? materialCount;

        [ObservableProperty]
        public Material? selectedMaterial;

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (cb != null) cb(this);
        }
    }
}
