using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Dressing_Room.ViewModels

{
	public partial class SignupViewModel: ObservableObject
	{
		[ObservableProperty]
		private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmpass;

        [RelayCommand]
        async Task Gotowardrobe()
        {
            await Shell.Current.GoToAsync(nameof(WardrobePage));
        }

        [RelayCommand]
        async Task Gobacktosignin()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

