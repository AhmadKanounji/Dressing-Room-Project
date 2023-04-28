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
    public partial class PopupEditProfViewModel : ObservableObject
    {
        private SignUpService _signUpService;
        private string user_info = Preferences.Get("user_info", "default_value");

        public PopupEditProfViewModel()
        {
            _signUpService = new SignUpService();

        }


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
                photo = ImageSource.FromStream(() => stream);
            }
            if (result == null) return;
            var stream2 = await tempphoto.OpenReadAsync();
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await stream2.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();


            }
            WeakReferenceMessenger.Default.Send(new RefreshMessage(photoBytes));
            await MopupService.Instance.PopAllAsync();



        }

        [RelayCommand]
        public async void RemovePhoto()
        {
           
            WeakReferenceMessenger.Default.Send(new RefreshMessage(null));
            await MopupService.Instance.PopAllAsync();
           
            
        }

        [RelayCommand]
        public async Task Choose()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions

            {
                Title = "Please pick a photo"
            });
            tempphoto = result;
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                photo = ImageSource.FromStream(() => stream);
            }
            if (result == null) return;
            var stream2 = await tempphoto.OpenReadAsync();
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await stream2.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();


            }
            WeakReferenceMessenger.Default.Send(new RefreshMessage(photoBytes));
            await MopupService.Instance.PopAllAsync();


        }

    }
}