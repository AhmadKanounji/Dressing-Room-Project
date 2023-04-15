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
    public ProfilePage()
    {
        InitializeComponent();
        ProfileViewModel profileViewModel = new ProfileViewModel();
        this.BindingContext = profileViewModel;

    }

    private void OnPlusSignClicked(System.Object sender, System.EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        imageButton.Rotation = 0;
        imageButton.RotateTo(90, 500);
        MopupService.Instance.PushAsync(new PopUpOne());

    }

    async void OnHangerClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WardrobePage));
    }
}