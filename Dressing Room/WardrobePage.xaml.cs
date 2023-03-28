using Dressing_Room.Wardrobe_Extensions;
using Mopups.Pages;
using Mopups.Services;
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
    protected override bool OnBackButtonPressed()
    {
        // Prevent going back to the login page
        return true;
    }
    private async void OnImage1Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(OutfitsPage));
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
    private async void OnImage7Clicked(object sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        imageButton.Rotation=0;
        await imageButton.RotateTo(45, 500);
        await MopupService.Instance.PushAsync(new PopUpPlus());
    }


}