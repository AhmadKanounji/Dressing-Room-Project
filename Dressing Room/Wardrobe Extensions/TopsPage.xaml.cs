using AndroidX.Lifecycle;
using Dressing_Room.Services;
using Dressing_Room.ViewModels;

namespace Dressing_Room.Wardrobe_Extensions;

public partial class TopsPage : ContentPage
{
	private TopsViewModel viewModel;
	public TopsPage()
	{
		InitializeComponent();
		viewModel = new TopsViewModel();
		this.BindingContext = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.refresh(); // call ViewModel method to load data
    }
}