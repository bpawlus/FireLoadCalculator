using CommunityToolkit.Maui.Views;
using FireLoadCalculator.Models;

namespace FireLoadCalculator.Views;

public partial class AllRoomsPage : ContentPage
{
	public AllRoomsPage(AllRooms vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}