using Dressing_Room.ViewModels;
using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpAdd 
{
	public PopUpAdd()
	{
		InitializeComponent();
		BindingContext= new ClothViewModel();
		
	}
    
}