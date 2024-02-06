using FireLoadCalculator.ViewModels;

namespace FireLoadCalculator.Views;

public partial class WaterReservoirPage : ContentPage
{
	private WaterReservoirViewModel vm;

    public WaterReservoirPage(WaterReservoirViewModel _vm)
	{
		InitializeComponent();
		BindingContext = vm = _vm;
	}

	private async void UseInternal(object sender, CheckedChangedEventArgs e)
	{
        if (e.Value)
        {
            Constants.TotalAreaCache = this.EntryField3.Text;
            Constants.TotalFireLoadDensityCache = this.EntryField1.Text;

            this.EntryField1.IsEnabled = false;
            this.EntryField3.IsEnabled = false;
            await vm.SetInternalData(true);
        }
        else
        {
            this.EntryField1.IsEnabled = true;
            this.EntryField3.IsEnabled = true;
            await vm.SetInternalData(false);
        }
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if(this.UseInternalCheck.IsChecked)
        {
            this.EntryField1.IsEnabled = false;
            this.EntryField3.IsEnabled = false;
            await vm.SetInternalData(true);
        }
    }
}