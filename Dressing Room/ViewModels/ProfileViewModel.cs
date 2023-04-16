using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;

namespace Dressing_Room.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        public SignUpService _signUpService;
        private string user_info_safe = Preferences.Get("user_name", "default_value");



        public ProfileViewModel()
        {
            _signUpService = new SignUpService();
            refresh();


        }
        [ObservableProperty]
        public byte[] photoSource;


        public async void refresh()
        {

            var allUsers = await _signUpService.GetUser();
            foreach (var user in allUsers)
            {
                if (user.Username == Preferences.Get("user_name", "deafault_value"))
                {
                    PhotoSource = user.Source;
                    break;
                }

            }



        }


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