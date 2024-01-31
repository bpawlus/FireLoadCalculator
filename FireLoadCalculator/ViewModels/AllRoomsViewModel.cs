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
        ObservableCollection<Room> rooms;

        RoomDatabase db;

        public AllRoomsViewModel(RoomDatabase _db)
        {
            Rooms = new ObservableCollection<Room>();
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
    }
}
