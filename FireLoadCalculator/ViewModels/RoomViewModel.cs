using CommunityToolkit.Mvvm.ComponentModel;
using FireLoadCalculator.Models;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.ViewModels
{
    public partial class RoomViewModel : ObservableObject
    {
        public RoomViewModel()
        {
        }

        public RoomViewModel(Room item)
        {
            Id = item.Id;
            Name = item.Name;
            Area = item.Area;
            CalculateTotalFireLoad();
        }

        public async Task CalculateTotalFireLoad()
        {
            var roommaterials = await Constants.RoomMaterial_DB.GetItemByRoomIdAsync((int)Id);
            double result = 0;
            foreach (var roommaterial in roommaterials)
            {
                if(roommaterial == null) continue;
                var material = await Constants.Material_DB.GetItemAsync(roommaterial.MaterialId);
                if (material == null) continue;
                result += material.CombustionHeat * roommaterial.MaterialWeight * roommaterial.MaterialCount;
            }

            try
            {
                result /= (double)Area;

                if (result > Constants.MaxTotalFireLoadDisplay) TotalFireLoad = String.Format(">{0:0.##}", Constants.MaxTotalFireLoadDisplay);
                else TotalFireLoad = String.Format("{0:0.##}", result);
            }
            catch(DivideByZeroException e)
            {
                TotalFireLoad = "∞";
            }
        }

        [ObservableProperty]
        public int? id;
        [ObservableProperty]
        public string? name;
        [ObservableProperty]
        public double? area;
        [ObservableProperty]
        public string? totalFireLoad;
    }
}
