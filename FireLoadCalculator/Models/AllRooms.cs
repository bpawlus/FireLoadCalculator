using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    public partial class AllRooms : ObservableObject
    {
        public AllRooms()
        {
            Rooms = new ObservableCollection<Room>();
        }

        [ObservableProperty]
        ObservableCollection<Room> rooms;
    }
}
