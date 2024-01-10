using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FireLoadCalculator.Models;

namespace FireLoadCalculator.Views;

public partial class AllMaterialsPage : ContentPage
{
    private Grid? content;

	public AllMaterialsPage(AllMaterials vm)
	{
        InitializeComponent();
        BindingContext = vm;
        /*      content = Content as Grid;
                var children = content?.Children;

                Button button = new Button();
                button.Text = "Add";
                content?.Add(button);

                return;*/
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