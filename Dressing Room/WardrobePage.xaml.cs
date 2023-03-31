using CommunityToolkit.Maui.Views;
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
        Routing.RegisterRoute(nameof(OutfitsPage),typeof(OutfitsPage));
        await Shell.Current.GoToAsync(nameof(OutfitsPage));
    }

    private async void OnImage2Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(TopsPage), typeof(TopsPage));
        await Shell.Current.GoToAsync(nameof(TopsPage));
    }

    private async void OnImage3Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(PantsPage), typeof(PantsPage));
        await Shell.Current.GoToAsync(nameof(PantsPage));
    }

    private async void OnImage4Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(ShoesPage), typeof(ShoesPage));
        await Shell.Current.GoToAsync(nameof(ShoesPage));
    }
    private async void OnImage5Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(JacketsPage), typeof(JacketsPage));
        await Shell.Current.GoToAsync(nameof(JacketsPage));
    }

    private async void OnImage6Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(AccessoriesPage), typeof(AccessoriesPage));
        await Shell.Current.GoToAsync(nameof(AccessoriesPage));
    }





    private async void OnImage7Clicked(object sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        imageButton.Rotation=0;
        await imageButton.RotateTo(45, 500);
        await MopupService.Instance.PushAsync(new PopUpOne());
        await imageButton.RotateTo(90, 500);
    }


}