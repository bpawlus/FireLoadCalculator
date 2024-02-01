using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using FireLoadCalculator.ViewModels;
using System.Diagnostics;

namespace FireLoadCalculator.Views;

public partial class AllRoomsPopup : Popup
{
    AllRoomsPopupViewModel vm;

    public AllRoomsPopup(AllRoomsPopupViewModel _vm)
	{
        InitializeComponent();
        BindingContext = vm = _vm;
        Debug.WriteLine(vm.Materials);
    }

    public async void Save(object sender, EventArgs e)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await vm.Save();
        await CloseAsync(cts);
    }
}