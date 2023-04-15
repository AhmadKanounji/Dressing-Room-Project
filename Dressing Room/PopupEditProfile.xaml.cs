using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class PopupEditProfile
{
	public PopupEditProfile()
	{
		InitializeComponent();
		PopupEditProfViewModel viewmodel = new PopupEditProfViewModel();
		this.BindingContext = viewmodel;
	}
}
