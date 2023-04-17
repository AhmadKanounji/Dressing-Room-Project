using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Dressing_Room.Messages;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{
	public partial class EditProfileViewModel: ObservableObject,IRecipient<RefreshMessage>
	{
        [ObservableProperty]
        private byte[] profileImage;

        [ObservableProperty]
        private string user_name = Preferences.Get("user_name", "default_value");

		[ObservableProperty]
		private string user_email = Preferences.Get("user_email", "default_value");

        [ObservableProperty]
        private string user_password = Preferences.Get("user_password", "default_value");



        private SignUpService _signUpService;

        public EditProfileViewModel()
        {
            _signUpService = new SignUpService();
            _ = refresh();
            WeakReferenceMessenger.Default.Register<RefreshMessage>(this);
        }
     


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



        public void Receive(RefreshMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ProfileImage = message.Value;
            });
        }
    }
}

