using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    internal class AllMaterials
    {
        public ObservableCollection<Material> Notes { get; set; }

        public AllMaterials() {
            Notes = new ObservableCollection<Material>();
        }
    }
}
