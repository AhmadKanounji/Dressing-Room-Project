using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;
using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpAdd 
{
	public PopUpAdd()
	{
		InitializeComponent();
		ClothingService clothingService = new ClothingService();
        BindingContext= new ClothViewModel(clothingService);
 

    }

  
}