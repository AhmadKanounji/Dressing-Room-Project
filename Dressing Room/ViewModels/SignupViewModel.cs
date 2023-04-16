using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;


namespace Dressing_Room.ViewModels

{
	public partial class SignupViewModel: ObservableObject

	{
        //Initializing the service
        private SignUpService service;
        public SignupViewModel(SignUpService s)
        {
            service = s;
            
            
        }
        

		[ObservableProperty]
		private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmpass;

        [ObservableProperty]
        private bool male;

        [ObservableProperty]
        private bool female;



        [RelayCommand]
        async Task Gotowardrobe()
        {
            //Checking if any of the fields are empty
            var fields = new List<string>();
            fields.Add(email);
            fields.Add(password);
            fields.Add(confirmpass);
            fields.Add(email);

            foreach(string s in fields)
            {
                if (s == null)
                {
                    await Shell.Current.DisplayAlert("Uh Oh", "Please enter all fields.", "Exit");
                    return;
                }
            }


            string gender= null;
            //check if the gender is checked:
            if (male == true)
            {
                gender = "Male";
            }

            else if(female == true)
            {
                gender = "Female";
            }
            else
            {
                await Shell.Current.DisplayAlert("Uh Oh", "Select a gender.", "Exit");
                return;
            }
            //Checking if the passwords match:
            if (password != confirmpass)
            {
             await   Shell.Current.DisplayAlert("Uh Oh","Your Passwords do not match! Please rewrite.", "Exit");
                return;

            }

           

            var user = new User
            {

                Username = name,
                Email = email,
                Password = password,
                Gender = gender

            };
            // now we have to check if there exists a user with the same username:
            var allUsers = await service.GetUser();
            foreach(User x in allUsers)
            {
                if (x.Username == name )
                {
                    await Shell.Current.DisplayAlert("Uh Oh", "Username already Exists! Please re-enter", "Exit");
                    return;
                }
                if (x.Email == email)
                {
                    await Shell.Current.DisplayAlert("Uh Oh", "Email is already in use! Please re-enter", "Exit");
                    return;
                }

            }

            Preferences.Set("user_name", Name);
            Preferences.Set("user_email", Email);
            Preferences.Set("user_password", Password);

            await service.AddUser(user);
            await Shell.Current.DisplayAlert("Success!", "Welcome to your wardrobe", "Exit");
            
            Routing.RegisterRoute(nameof(WardrobePage),typeof(WardrobePage));

            await Shell.Current.GoToAsync(nameof(WardrobePage));

            Routing.UnRegisterRoute(nameof(Signup));
        }

        [RelayCommand]
        async Task Gobacktosignin()
        {
            await Shell.Current.GoToAsync("..");
        }



        

     


    }
}

