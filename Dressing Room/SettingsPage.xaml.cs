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

    async void TermsAndConditionsClicked(System.Object sender, System.EventArgs e)
    {
        await MopupService.Instance.PushAsync(new TermsAndCondition());
    }
}