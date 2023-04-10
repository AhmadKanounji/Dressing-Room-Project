using Dressing_Room.Services;
using Dressing_Room.ViewModels;

namespace Dressing_Room.Wardrobe_Extensions;

public partial class TopsPage : ContentPage
{
	public TopsPage()
	{
		InitializeComponent();
		TopsViewModel viewModel = new TopsViewModel();
		this.BindingContext = viewModel;
	}
}