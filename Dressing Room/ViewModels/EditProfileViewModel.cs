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

		[RelayCommand]
		async void OpenPopup()
		{
			await MopupService.Instance.PushAsync(new PopupEditProfile());
        }
	}
}

