using CommunityToolkit.Mvvm.ComponentModel;
using FireLoadCalculator.Data;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    public partial class AllMaterials : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Material> materials;

        MaterialDatabase db;

        public AllMaterials(MaterialDatabase _db)
        {
            Materials = new ObservableCollection<Material>();
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
