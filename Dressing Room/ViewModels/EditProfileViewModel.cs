using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{
	public partial class EditProfileViewModel: ObservableObject
	{
		[ObservableProperty]
		private ImageSource profileImage = "profilepicicon.png";

        [ObservableProperty]
        private string user_name = Preferences.Get("user_name", "default_value");

		[ObservableProperty]
		private string user_email = Preferences.Get("user_email", "default_value");

        [ObservableProperty]
        private string user_password = Preferences.Get("user_password", "default_value");


        [RelayCommand]
		async void OpenPopup()
		{
			await MopupService.Instance.PushAsync(new PopupEditProfile());
        }
	}
}

