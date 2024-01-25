using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.ViewModels;
using FireLoadCalculator.Views;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    public partial class AllRooms : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Room> rooms;

        RoomDatabase db;
        private readonly IPopupService popupService;

        public AllRooms(IPopupService popupService, RoomDatabase _db)
        {
            this.popupService = popupService;
            Rooms = new ObservableCollection<Room>();
            db = _db;
        }

        public async Task UpdateMaterials()
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
            return this.popupService.ShowPopupAsync<AllRoomsPopupViewModel>();
        }
    }
}
