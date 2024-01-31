using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.ViewModels;

namespace FireLoadCalculator.Views;

public partial class AllRoomsPage : ContentPage
{
    AllRoomsViewModel vm;
    AllMaterialsViewModel vm_materials;
    IPopupService popupService;

    public AllRoomsPage(AllRoomsViewModel _vm, AllMaterialsViewModel _vm_materials, IPopupService _popupService)
	{
		InitializeComponent();
        BindingContext = vm = _vm;
        vm_materials = _vm_materials;
        popupService = _popupService; 
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await vm.UpdateRooms();
        await vm_materials.UpdateMaterials();
    }

    public async void DisplayPopup(object sender, EventArgs e)
    {
        await popupService.ShowPopupAsync<AllRoomsPopupViewModel>(onPresenting: vm => vm.OverrideData(vm_materials.Materials));
        await vm.UpdateRooms();
    }
}