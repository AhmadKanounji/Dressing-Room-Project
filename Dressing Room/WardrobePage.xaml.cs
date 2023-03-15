using Dressing_Room.Wardrobe_Extensions;
using System.ComponentModel;
using System.Net.Security;
using System.Windows.Input;

namespace Dressing_Room;

public partial class WardrobePage : ContentPage
{
    
    public WardrobePage()
	{
		InitializeComponent();
    }
    private void OnImage1Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OutfitsPage());
    }

    private void OnImage2Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TopsPage());
    }

    private void OnImage3Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PantsPage());
    }

    private void OnImage4Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ShoesPage());
    }
    private void OnImage5Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new JacketsPage());
    }

    private void OnImage6Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AccessoriesPage());
    }


}