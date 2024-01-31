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
using System.Threading.Channels;

namespace FireLoadCalculator.ViewModels
{
    public partial class AllRoomsPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Material> materials;

        [ObservableProperty]
        ObservableCollection<RoomMaterials> roommaterials;

        [ObservableProperty]
        string roomname;
        [ObservableProperty]
        string roomarea;

        RoomDatabase room_db;
        RoomMaterialsDatabase roommaterials_db;

        public void ChangeRoommaterials()
        {
            Debug.WriteLine("I will add.");
        }

        public AllRoomsPopupViewModel(RoomDatabase _room_db, RoomMaterialsDatabase _roommaterials_db)
        {
            room_db = _room_db;
            roommaterials = new ObservableCollection<RoomMaterials>()
            {
                new RoomMaterials(0, 1, 5, 5, new RoomMaterialsDelegate(ChangeRoommaterials)),
                new RoomMaterials(0, 2, 15, 5, new RoomMaterialsDelegate(ChangeRoommaterials)),
                new RoomMaterials(0, 3, 5, 15, new RoomMaterialsDelegate(ChangeRoommaterials))
            };
        }

        public void OverrideData(ObservableCollection<Material> materials)
        {
            Materials = materials;
            return;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            string changed = e.PropertyName ?? "";
            Debug.WriteLine($"Changed {changed}");
        }

        public async Task Save()
        {
            int roomarea_tosave = 0;
            string roomname_tosave = Roomname != null ? Roomname : "";
            try
            {
                roomarea_tosave = Int32.Parse(Roomarea);
            }
            catch (FormatException)
            {
            }
            catch(ArgumentNullException)
            {
            }
            await room_db.SaveItemAsync(new Room(roomname_tosave, roomarea_tosave));
        }

        [RelayCommand]
        public async Task Delete(int id)
        {
            return;
            //await room_db.DeleteItemAsync(null);
        }

        [RelayCommand]
        public void Edit()
        {
            foreach(var v in Roommaterials)
            {
                v.MaterialWeight = 0;
                v.MaterialCount = 0;
            }
        }
    }
}
