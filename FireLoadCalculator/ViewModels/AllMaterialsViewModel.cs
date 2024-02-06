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
            materials = new ObservableCollection<Material>();
        }

        public async Task UpdateMaterials()
        {
            var items = await Constants.Material_DB.GetItemsAsync();
            Materials.Clear();
            Constants.Material_DB_List.Clear();

            foreach (var item in items)
            {
                Materials.Add(item);
                Constants.Material_DB_List.Add(item);
            }
        }
    }
}
