using FireLoadCalculator.ViewModels;

namespace FireLoadCalculator.Views;

public partial class AllMaterialsPage : ContentPage
{
    AllMaterialsViewModel vm;

    public AllMaterialsPage(AllMaterialsViewModel _vm)
	{
        InitializeComponent();
        BindingContext = vm = _vm;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await vm.UpdateMaterials();
    }
}