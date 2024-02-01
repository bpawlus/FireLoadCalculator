using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;
using FireLoadCalculator.Views;
using Microsoft.Maui.Controls.Compatibility;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Channels;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllRoomsPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Material> materials;

        [ObservableProperty]
        ObservableCollection<RoomMaterialViewModel> roomMaterials;

        [ObservableProperty]
        RoomViewModel? selectedRoom;

        RoomMaterialViewModelDelegate callback;

        public void ChangeRoommaterials(RoomMaterialViewModel item)
        {
            if (item == RoomMaterials?.LastOrDefault())
                RoomMaterials.Add(new RoomMaterialViewModel(callback));
        }

        public AllRoomsPopupViewModel()
        {
            callback = new RoomMaterialViewModelDelegate(ChangeRoommaterials);
        }

        public async Task InitializeData(int? id)
        {
            var materials_fromdb = await Constants.Material_DB.GetItemsAsync();
            Materials = new ObservableCollection<Material>(materials_fromdb);

            if (id != null)
            {
                Room room = await Constants.Room_DB.GetItemAsync((int)id);
                SelectedRoom = new RoomViewModel(room);

                RoomMaterials = new ObservableCollection<RoomMaterialViewModel>();
                var items = await Constants.RoomMaterial_DB.GetItemByRoomIdAsync((int)id);
                foreach (var item in items)
                {
                    RoomMaterials.Add(new RoomMaterialViewModel(item, null, callback));
                };

                int count = RoomMaterials?.Count ?? 1;
                for (int i = 0; i < count; i++)
                {
                    RoomMaterials[i].SelectedMaterial = Materials.Where(m => m.Id == items[i].MaterialId).FirstOrDefault();
                    Debug.WriteLine($"RoomMaterials[{i}].SelectedMaterial is {RoomMaterials[i].SelectedMaterial?.Name ?? "NULL"}. Materials count: {Materials.Count}");
                }
            }
            else
            {
                SelectedRoom = new RoomViewModel();

                RoomMaterials = new ObservableCollection<RoomMaterialViewModel>()
                {
                    new RoomMaterialViewModel(callback),
                };
            }
        }

        public async Task Save()
        {
            Room room = new Room(SelectedRoom);
            await Constants.Room_DB.SaveItemAsync(room);

            int count = RoomMaterials?.Count ?? 1;
            for (int i = 0; i < count - 1; i++)
            {
                RoomMaterials[i].RoomId ??= room.Id;

                Debug.WriteLine($"Saving RoomMaterials[{i}]. Material Id: {RoomMaterials[i].SelectedMaterial?.Name ?? "NULL"}");

                await Constants.RoomMaterial_DB.SaveItemAsync(new RoomMaterial(RoomMaterials[i]));
            };
        }

        [RelayCommand]
        public async Task DeleteRoomMaterial(RoomMaterialViewModel item)
        {
            if (item != RoomMaterials?.LastOrDefault())
            {
                RoomMaterials?.Remove(item);
                await Constants.RoomMaterial_DB.DeleteItemAsync(new RoomMaterial(item));
            }
        }

        [RelayCommand]
        public void DebugEdit()
        {
            int count = RoomMaterials?.Count ?? 1;
            for (int i = 0; i < count-1; i++)
            {
                RoomMaterials[i].SelectedMaterial = Materials[3];
            }
        }
    }
}
