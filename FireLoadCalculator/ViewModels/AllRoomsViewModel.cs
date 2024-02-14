using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using FireLoadCalculator.Views;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllRoomsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<RoomViewModel> rooms;

        IPopupService popupService;

        [ObservableProperty]
        string totalFireLoadDensity;
        [ObservableProperty]
        double totalArea;

        [ObservableProperty]
        string debug;

        public AllRoomsViewModel(IPopupService _popupService)
        {
            Rooms = new ObservableCollection<RoomViewModel>();
            popupService = _popupService;
        }

        public async Task UpdateRooms()
        {
            var items = await Constants.Room_DB.GetItemsAsync();
            Rooms.Clear();
            foreach (var item in items)
                Rooms.Add(new RoomViewModel(item));
            await CalculateTotalFireLoad();
        }

        [RelayCommand]
        public async Task Delete(RoomViewModel item)
        {
            await Constants.Room_DB.DeleteItemAsync(new Room(item));
            await UpdateRooms();
        } 

        public async Task CalculateTotalFireLoad()
        {
            TotalArea = await Constants.Room_DB.GetItemsTotalArea();
            TotalFireLoadDensity = await Constants.RoomMaterial_DB.GetFireLoadDensityAllRooms();
        }

        [RelayCommand]
        public async Task DisplayPopup(int? id)
        {
            await popupService.ShowPopupAsync<AllRoomsPopupViewModel>(onPresenting: async vm => await vm.InitializeData(id));
            await UpdateRooms();
        }
    }
}
