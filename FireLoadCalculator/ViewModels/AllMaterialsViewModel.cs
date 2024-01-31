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

        MaterialDatabase db;
        public AllMaterialsViewModel(MaterialDatabase _db)
        {
            Materials = new ObservableCollection<Material>()
            {
                new Material("M1", 20, 0),
                new Material("M2", 15, 0),
                new Material("M3", 20, 0),
                new Material("M4", 25, 0),
            };
            db = _db;
        }

        public async Task UpdateMaterials()
        {
            var items = await db.GetItemsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Materials.Clear();
                foreach (var item in items)
                    Materials.Add(item);
            });
        }
    }
}
