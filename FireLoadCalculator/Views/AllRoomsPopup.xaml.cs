using CommunityToolkit.Maui.Views;
using FireLoadCalculator.ViewModels;

namespace FireLoadCalculator.Views;

public partial class AllRoomsPopup : Popup
{
	public AllRoomsPopup(AllRoomsPopupViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}