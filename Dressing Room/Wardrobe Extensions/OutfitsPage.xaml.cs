using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace Dressing_Room;

public partial class OutfitsPage : ContentPage
{
    public OutfitsPage()
	{
		InitializeComponent();

		
	}
    private async void OnImageClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//WardPage");


    }
}