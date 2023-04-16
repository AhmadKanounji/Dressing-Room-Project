using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{
    public partial class EditProfileViewModel : ObservableObject
    {
        private SignUpService _signUpService;
        public EditProfileViewModel()
        {
            _signUpService = new SignUpService();
            _ = refresh();
        }
        [ObservableProperty]
        private byte[] profileImage;


        public async Task refresh()
        {
            var allUsers = await _signUpService.GetUser();
            foreach (User user in allUsers)
            {
                if (user.Username == Preferences.Get("user_name", "deafult_value"))
                {
                    ProfileImage = user.Source;
                    break;
                }
            }


        }

        [RelayCommand]
        async void OpenPopup()
        {
            await MopupService.Instance.PushAsync(new PopupEditProfile());
        }
    }
}

