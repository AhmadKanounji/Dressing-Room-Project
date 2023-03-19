﻿using System;
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
            fields.Add(Email);
            fields.Add(Password);
            fields.Add(Confirmpass);
            fields.Add(Email);

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
            if (Male == true)
            {
                gender = "Male";
            }

            else if(Female == true)
            {
                gender = "Female";
            }
            else
            {
                await Shell.Current.DisplayAlert("Uh Oh", "Select a gender.", "Exit");
                return;
            }
            //Checking if the passwords match:
            if (Password != Confirmpass)
            {
             await   Shell.Current.DisplayAlert("Uh Oh","Your Passwords do not match! Please rewrite.", "Exit");
                return;

            }

            var user = new User
            {

                Username = Name,
                Email = Email,
                Password = Password,
                Gender = gender

            };
            await service.AddUser(user);
            await Shell.Current.DisplayAlert("Success!", "Welcome to your wardrobe", "Exit");

            await Shell.Current.GoToAsync(nameof(WardrobePage));
        }

        [RelayCommand]
        async Task Gobacktosignin()
        {
            await Shell.Current.GoToAsync("..");
        }

     


    }
}

