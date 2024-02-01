using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using FireLoadCalculator.Views;
using System.Collections.ObjectModel;
using static SQLite.SQLite3;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllRoomsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<RoomViewModel> rooms;

        IPopupService popupService;

        public AllRoomsViewModel(AllMaterialsViewModel _vm_materials, IPopupService _popupService)
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
        }

        [RelayCommand]
        public async Task Delete(RoomViewModel item)
        {
            await Constants.Room_DB.DeleteItemAsync(new Room(item));
            Rooms.Remove(item);
        }

        [RelayCommand]
        public async Task DisplayPopup(int? id)
        {
            await popupService.ShowPopupAsync<AllRoomsPopupViewModel>(onPresenting: async vm => await vm.InitializeData(id));
            await UpdateRooms();
        }
    }
}
