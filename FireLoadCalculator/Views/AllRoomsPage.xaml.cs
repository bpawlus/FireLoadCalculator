using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.ViewModels;

namespace FireLoadCalculator.Views;

public partial class AllRoomsPage : ContentPage
{
    AllRoomsViewModel vm;
    AllMaterialsViewModel vm_materials;

    public AllRoomsPage(AllRoomsViewModel _vm, AllMaterialsViewModel _vm_materials)
	{
		InitializeComponent();
        BindingContext = vm = _vm;
        vm_materials = _vm_materials;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await vm.UpdateRooms();
        await vm_materials.UpdateMaterials();
    }
}