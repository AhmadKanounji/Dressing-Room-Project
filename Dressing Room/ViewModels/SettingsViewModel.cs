using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{

    public partial class SettingsViewModel : ObservableObject
    {
        private SignUpService _signupservice;

        public SettingsViewModel()
        {
            _signupservice = new SignUpService();
        }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordCheck { get; set; }





        [RelayCommand]
        async Task ChangePassword()
        {
            var Username = Preferences.Get("user_name", "default_value");
            string password = await _signupservice.getPassword(Username);
            if (CurrentPassword != password)
            {
                await Shell.Current.DisplayAlert("Error", "Old Password doesn't match!", "Exit");
                return;

            }

            if (NewPassword == NewPasswordCheck)
            {
                await _signupservice.UpdateUserPassword(Username, NewPassword);

                await MopupService.Instance.PopAllAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "New Password not identical. Please re-enter", "Exit");
            }
        }
        [RelayCommand]
        async Task DeleteAccount()
        {
            await MopupService.Instance.PopAllAsync();
            await Shell.Current.GoToAsync("//MainPage");
            await _signupservice.deleteAccount(Preferences.Get("user_name", "default_value"));
        }
    }
}

