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
            var result = await Constants.RoomMaterial_DB.GetFireLoadByRoomId((int)Id);

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
