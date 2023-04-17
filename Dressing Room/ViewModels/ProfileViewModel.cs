using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Services;

namespace Dressing_Room.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string user_info = Preferences.Get("user_name", "default_value");

        [RelayCommand]
        async void GoToEditProfile()
        {
            Routing.RegisterRoute(nameof(EditProfile), typeof(EditProfile));
            await Shell.Current.GoToAsync(nameof(EditProfile));
        }
      




       
            public SignUpService _signUpService;




            public ProfileViewModel()
            {
                _signUpService = new SignUpService();
                refresh();

            }
            [ObservableProperty]
            public byte[] photoSource;


            public async void refresh()
            {

                var allUsers =  await _signUpService.GetUser();
                foreach (var user in allUsers)
                {
                    if (user.Username == Preferences.Get("user_name", "deafault_value"))
                    {
                        PhotoSource = user.Source;
                        break;
                    }

                }


            }


        }
    }

