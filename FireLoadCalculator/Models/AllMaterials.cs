using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    public partial class AllMaterials : ObservableObject
    {
        public AllMaterials() {
            Materials =
            [
                new Material("M1", 20, 0),
                new Material("M2", 20, 0),
                new Material("M3", 20, 0),
                new Material("M4", 20, 0),
                new Material("M5", 20, 0),
            ];
        }

        [ObservableProperty]
        ObservableCollection<Material> materials;
    }
}
