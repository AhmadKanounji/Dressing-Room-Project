using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{
    public partial class PopupEditProfViewModel : ObservableObject
    {
        private SignUpService _signUpService;
        private string user_info = Preferences.Get("user_info", "default_value");

        public PopupEditProfViewModel()
        {
            _signUpService = new SignUpService();

        }

        [ObservableProperty]
        public ImageSource photo;

        public FileResult tempphoto;

        [RelayCommand]
        public async void TakePhoto()
        {
            var result = await MediaPicker.CapturePhotoAsync();
            tempphoto = result;

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                Photo = ImageSource.FromStream(() => stream);
            }



        }

        [RelayCommand]
        public async void Confirm()
        {

            if (tempphoto == null) return;
            var stream = await tempphoto.OpenReadAsync();
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();


            }
            //create a user model to be updated but get info first:
            var allUsers = await _signUpService.GetUser();
            var user = new User();
            foreach (User x in allUsers)
            {
                if (x.Username == Preferences.Get("user_name", "default_value"))
                {
                    user.Username = x.Username;
                    user.Password = x.Password;
                    user.Email = x.Email;
                    user.Source = photoBytes;
                    user.Gender = x.Gender;
                    break;
                }
            }


            await _signUpService.UpdateUserPhoto(user);
            await MopupService.Instance.PopAllAsync();
        }
    }
}

