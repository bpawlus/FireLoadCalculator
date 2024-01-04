using FireLoadCalculator.ViewModel;

namespace FireLoadCalculator;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}