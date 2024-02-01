using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using Microsoft.Maui.Controls.Compatibility;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllMaterialsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Material> materials;

        public AllMaterialsViewModel()
        {
            Materials = new ObservableCollection<Material>()
            {
                new Material("M1", 20, 0),
                new Material("M2", 15, 0),
                new Material("M3", 20, 0),
                new Material("M4", 25, 0),
            };
        }

        public async Task UpdateMaterials()
        {
            var items = await Constants.Material_DB.GetItemsAsync();
            Materials.Clear();
            foreach (var item in items)
                Materials.Add(item);
        }
    }
}
