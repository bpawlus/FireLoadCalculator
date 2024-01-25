using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using Microsoft.Maui.Controls.Compatibility;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllRoomsPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Material> materials;

        [ObservableProperty]
        ObservableCollection<RoomMaterialsDTO> roommaterials;

        public AllRoomsPopupViewModel()
        {

        }

        public void OverrideData(ObservableCollection<Material> materials)
        {
            Materials = materials;
            return;
        }
    }
}
