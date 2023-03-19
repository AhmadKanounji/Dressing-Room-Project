using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
namespace Dressing_Room.ViewModels
{
	public partial class MainPageViewModel: ObservableObject
	{
		[ObservableProperty]
		private string mail;

		[ObservableProperty]
		private string password;

        [RelayCommand]
        async Task Gotosignup()
        {
            await Shell.Current.GoToAsync(nameof(Signup));
        }
    }
}

