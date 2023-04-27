using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Mopups.Services;


namespace Dressing_Room;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }
    private void OnImageClicked(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new LogoutPopup());
    }
    private void OnImage2Clicked(object sender, EventArgs e)
    {
        SignUpService s = new SignUpService();
        SettingsViewModel svm = new SettingsViewModel();
        MopupService.Instance.PushAsync(new ChangePasswordPopup(svm));
    }
    private void GoToDelete(object sender, EventArgs e)
    {
        SettingsViewModel svm = new SettingsViewModel();
        MopupService.Instance.PushAsync(new DeleteAccountPopUp(svm));
    }
    private async void GoToWardrobe(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WardrobePage));
    }

    //////////////////////////////////////
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
}