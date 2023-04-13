using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using System;

namespace Dressing_Room.ViewModels
{
	public partial class MainPageViewModel: ObservableObject
	{

        //Initializing the service
        private SignUpService service;
        public MainPageViewModel(SignUpService s)
        {
            service = s;
            
        }

        [ObservableProperty]
		private string username;

		[ObservableProperty]
		private string password;

        [RelayCommand]
        async Task Gotosignup()
        {
            await Shell.Current.GoToAsync(nameof(Signup));
        }

        [RelayCommand]
        
        async Task Gotowardrobe() 
        {



            if (password ==null || username==null) return;
                
            
            var done = false;
            var allUsers = await service.GetUser();
            foreach(User x in allUsers)
            {
                if (x.Username == username && x.Password==password)
                {   

                    done = true;
                    Routing.RegisterRoute(nameof(WardrobePage), typeof(WardrobePage));
                    await Shell.Current.GoToAsync(nameof(WardrobePage));
                    Routing.UnRegisterRoute(nameof(MainPage));
                    break;
                    
                }
            }
            if (!done)
            {
                await Shell.Current.DisplayAlert("Error", "Invalid Credentials. Please re-enter", "Exit");
                return;
            }

            //Else we Keep track of who signed in
            Preferences.Set("user_name", Username);

        }


    }
}

