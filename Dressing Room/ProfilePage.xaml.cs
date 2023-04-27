using CommunityToolkit.Maui.Views;
using Dressing_Room.ViewModels;
using Dressing_Room.Wardrobe_Extensions;
using Mopups.Pages;
using Mopups.Services;
using System.ComponentModel;
using System.Net.Security;
using System.Windows.Input;

namespace Dressing_Room;

public partial class ProfilePage : ContentPage
{
    private ProfileViewModel viewModel;
    public ProfilePage()
    {

        InitializeComponent();
        viewModel = new ProfileViewModel();
        this.BindingContext = viewModel;

    }

    private async void OnImage1Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(OutfitsPage), typeof(OutfitsPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(OutfitsPage));
    }

    private async void OnImage2Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(TopsPage), typeof(TopsPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(TopsPage));
    }

    private async void OnImage3Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(PantsPage), typeof(PantsPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(PantsPage));
    }

    private async void OnImage4Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(ShoesPage), typeof(ShoesPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(ShoesPage));
    }
    private async void OnImage5Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(JacketsPage), typeof(JacketsPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(JacketsPage));
    }

    private async void OnImage6Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(AccessoriesPage), typeof(AccessoriesPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(AccessoriesPage));
    }





    private void OnImage7Clicked(object sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        imageButton.Rotation = 0;
        imageButton.RotateTo(90, 500);
        MopupService.Instance.PushAsync(new PopUpOne());

    }

    async void GoToProfile(System.Object sender, System.EventArgs e)
    {
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }

    async void GoToSettings(System.Object sender, System.EventArgs e)
    {
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
    async void GoToHomePage(System.Object sender, System.EventArgs e)
    {
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(HomePage));
    }
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {

        await MopupService.Instance.PushAsync(new RemoveBugPopup());
        await Shell.Current.GoToAsync(nameof(WardrobePage));

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.User_info = Preferences.Get("user_name", "default_value");
        for (int i = 0; i < 10; i++)
        {
            viewModel.refresh();
        }
        viewModel.RefreshOutfitsNumber();
        viewModel.Refresh();


    }


}