using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dressing_Room.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string user_info = Preferences.Get("user_name", "default_value");

        [RelayCommand]
        async void GoToEditProfile()
        {
            Routing.RegisterRoute(nameof(EditProfile), typeof(EditProfile));
            await Shell.Current.GoToAsync(nameof(EditProfile));
        }
    }
}