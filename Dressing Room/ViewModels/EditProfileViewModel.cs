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
    public partial class EditProfileViewModel : ObservableObject, IRecipient<RefreshMessage>
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
        private ClothingService _clothingService;
        private OutfitsService _outfitService;
        public EditProfileViewModel()
        {
            _signUpService = new SignUpService();
            _clothingService = new ClothingService();
            _outfitService = new OutfitsService();
            Refresh();
            WeakReferenceMessenger.Default.Register<RefreshMessage>(this);
        }



        public async void Refresh()
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
        public async Task SaveChanges()
        {

            if (User_email == "" || User_password == "")
            {
                await Shell.Current.DisplayAlert("Error", "Invalid Entries. Please re-enter", "Exit");
                return;
            }
            //Updating all clothes with that username
            var allClothes = await _clothingService.GetClothes();
            foreach (Clothes cloth in allClothes)
            {
                if (cloth.UserID == Preferences.Get("user_name", "deafult_value"))
                {
                    await _clothingService.UpdateClothes(Preferences.Get("user_name", "default_value"), User_name);
                }
            }

            //updating outfis:
            var allOutfits = await _outfitService.GetOutfits();
            foreach (Outfits outfits in allOutfits)
            {
                if (outfits.UserID == Preferences.Get("user_name", "default_value"))
                {
                    await _outfitService.UpdateOutfits(Preferences.Get("user_name", "default_value"), User_name, ProfileImage);
                }
            }

            //updating email and username and photo
            await _signUpService.UpdateUser(Preferences.Get("user_name", "deafult_value"), User_name, User_email, ProfileImage);
            await Shell.Current.DisplayAlert("Success!", "Changes have been saved", "Exit");
            Preferences.Set("user_name", User_name);
            Preferences.Set("user_email", User_email);

        }

        [RelayCommand]
        async void OpenPopup()
        {
            await MopupService.Instance.PushAsync(new PopupEditProfile());
        }


        [RelayCommand]
        public void Receive(RefreshMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ProfileImage = message.Value;
            });
        }
    }
}