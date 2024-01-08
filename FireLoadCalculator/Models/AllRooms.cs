using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    internal class AllRooms
    {
        public ObservableCollection<Room> Rooms { get; set; }

        public AllRooms()
        {
            Rooms = new ObservableCollection<Room>();
        }
    }
}
