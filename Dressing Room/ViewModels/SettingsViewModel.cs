﻿using CommunityToolkit.Mvvm.ComponentModel;
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


            //checking if password is valid
            if (NewPassword.Length < 8)
            {
                await Shell.Current.DisplayAlert("Uh Oh", "Your Password needs to be longer than 8 characters", "Exit");
                return;
            }
            bool hasLowerCase = NewPassword.Any(char.IsLower);
            bool hasUpperCase = NewPassword.Any(char.IsUpper);
            bool hasDigit = NewPassword.Any(char.IsDigit);
            bool hasSymbol = NewPassword.Any(char.IsSymbol) || NewPassword.Any(char.IsPunctuation);

            if (!(hasLowerCase && hasUpperCase && hasDigit && hasSymbol))
            {
                await Shell.Current.DisplayAlert("Uh Oh", "Your Password needs to include a lowercase and uppercase letter,a digit and a symbol or punctuation", "Exit");
                return;
            }

            //checking if comfirm password is correct
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

