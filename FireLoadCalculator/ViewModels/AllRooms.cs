using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.ViewModels;
using FireLoadCalculator.Views;
using System.Collections.ObjectModel;

namespace FireLoadCalculator.Models
{
    public partial class AllRooms : ObservableObject
    {
        private readonly IPopupService popupService;

        public AllRooms(IPopupService popupService)
        {
            this.popupService = popupService;
            Rooms = [
                new Room("R1", 100),
                new Room("R2", 200),
            ];
        }

        [RelayCommand]
        public Task DisplayPopup()
        {
            return this.popupService.ShowPopupAsync<AllRoomsPopupViewModel>();
        }

        [ObservableProperty]
        ObservableCollection<Room> rooms;
    }
}
