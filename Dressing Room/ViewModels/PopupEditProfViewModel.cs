using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Services;

namespace Dressing_Room.ViewModels
{
	public partial class PopupEditProfViewModel: ObservableObject 
	{
        private SignUpService _signUpService;

        public PopupEditProfViewModel(SignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        private ImageSource Photo;

        private FileResult tempphoto;

        [RelayCommand]
		async void TakePhoto()
		{
            var result = await MediaPicker.CapturePhotoAsync();
            tempphoto = result;

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                Photo = ImageSource.FromStream(() => stream);
            }

            var stream2 = await tempphoto.OpenReadAsync();
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await stream2.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();
            }

        }
    }
}

