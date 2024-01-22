using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Data;
using FireLoadCalculator.Models;

namespace FireLoadCalculator.Views;

public partial class AllMaterialsPage : ContentPage
{
    private Grid? content;
    MaterialDatabase db;
    AllMaterials vm;

    public AllMaterialsPage(AllMaterials _vm)
	{
        InitializeComponent();
        BindingContext = vm = _vm;

        /*      content = Content as Grid;
                var children = content?.Children;

                Button button = new Button();
                button.Text = "Add";
                content?.Add(button);

                return;*/
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await vm.UpdateMaterials();
    }

    public void GrayOut()
    {
        var children = content?.Children;

        if (children != null)
        {
            foreach (var child in children)
            {
                if (child is BoxView)
                {
                    ((BoxView)child).Color = new Color(128, 128, 128);
                }
            }
        }
    }
}