using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string user_info = Preferences.Get("user_name", "default_value");
        [ObservableProperty]
        private int num_outfits = 0;

        [RelayCommand]
        async void GoToEditProfile()
        {
            await MopupService.Instance.PushAsync(new RemoveBugPopup());
            Routing.RegisterRoute(nameof(EditProfile), typeof(EditProfile));
            await Shell.Current.GoToAsync(nameof(EditProfile));
        }






        public SignUpService _signUpService;
        public OutfitsService _outfitsService;




        public ProfileViewModel()
        {
            _signUpService = new SignUpService();
            _outfitsService = new OutfitsService();
            refresh();

        }
        [ObservableProperty]
        public byte[] photoSource;


        public async void refresh()
        {

            var allUsers = await _signUpService.GetUser();
            foreach (var user in allUsers)
            {
                if (user.Username == Preferences.Get("user_name", "deafault_value"))
                {
                    PhotoSource = user.Source;
                    break;
                }

            }


        }

        public async void RefreshOutfitsNumber()
        {
            var allOutfits = await _outfitsService.GetOutfits();
            foreach (Outfits outfit in allOutfits)
            {
                if (outfit.UserID == User_info) Num_outfits++;
            }
        }


    }
}
