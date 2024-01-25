using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using FireLoadCalculator.Views;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllRoomsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Room> rooms;

        RoomDatabase db;
        AllMaterialsViewModel vm_materials;
        private readonly IPopupService popupService;

        public AllRoomsViewModel(AllMaterialsViewModel _vm_materials, IPopupService _popupService, RoomDatabase _db)
        {
            popupService = _popupService;
            vm_materials = _vm_materials;
            //Rooms = new ObservableCollection<Room>();
            Rooms = new ObservableCollection<Room>()
            {
                new Room("Room 1", 200),
                new Room("Room 2", 100),
                new Room("Room 3", 80),
                new Room("Room 4", 250),
                new Room("Room 1", 200),
                new Room("Room 2", 100),
                new Room("Room 3", 80),
                new Room("Room 4", 250),
                new Room("Room 1", 200),
                new Room("Room 2", 100),
                new Room("Room 3", 80),
                new Room("Room 4", 250),
                new Room("Room 1", 200),
                new Room("Room 2", 100),
                new Room("Room 3", 80),
                new Room("Room 4", 250),
                new Room("Room 1", 200),
                new Room("Room 2", 100),
                new Room("Room 3", 80),
                new Room("Room 4", 250),
            };
            db = _db;
        }

        public async Task UpdateRooms()
        {
            var items = await db.GetItemsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Rooms.Clear();
                foreach (var item in items)
                    Rooms.Add(item);
            });
        }

        [RelayCommand]
        public Task DisplayPopup()
        {
            return this.popupService.ShowPopupAsync<AllRoomsPopupViewModel>(onPresenting: vm => vm.OverrideData(vm_materials.Materials));
        }
    }
}
