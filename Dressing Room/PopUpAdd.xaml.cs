using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;
using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpAdd 
{
	public PopUpAdd()
	{
		InitializeComponent();
        BindingContext= new ClothViewModel();
 

    }

    async private void Button_Clicked(object sender, EventArgs e)
    {
        var result = await MediaPicker.CapturePhotoAsync();
        var stream = await result.OpenReadAsync();
        resultImage.Source = ImageSource.FromStream(() => stream);
    }
}