using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;
using Mopups.Services;

namespace Dressing_Room;

public partial class EditProfile : ContentPage
{
	public EditProfile()
	{
		InitializeComponent();

		EditProfileViewModel viewModel = new EditProfileViewModel();
		this.BindingContext = viewModel;
	}
}
