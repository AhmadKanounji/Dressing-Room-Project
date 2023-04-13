using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Microsoft.Maui.Controls;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.ViewModels
{
    public partial class ClothViewModel : ObservableObject
    {
        private ClothingService _clothingService;
        public ClothViewModel(ClothingService clothingService)
        {
            _clothingService = clothingService;
        }

        [ObservableProperty]

        private ImageSource photo;


        [ObservableProperty]
        private string type;
        [ObservableProperty]

        private string color;
        [ObservableProperty]
        private string categories;


        private FileResult tempphoto;


       

        [RelayCommand]
        async void TakePhoto()
        {
            if (Categories == null || Type == null || Color == null)
            {
                await Shell.Current.DisplayAlert("Error", "Please enter all fields", "exit");
                return;
            }
            
            var result = await MediaPicker.CapturePhotoAsync();
            tempphoto = result;
      
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                Photo = ImageSource.FromStream(() => stream);


                
            }



           
        }

        [RelayCommand]
        async Task AddToCloset()
        {

            //Get the User_name:
            var Username = Preferences.Get("user_name", "default_value");
            if (Photo == null)
            {
                await Shell.Current.DisplayAlert("Oh No", "Please Take a Photo!", "Exit");
                return;
            }

            if (string.IsNullOrEmpty(Type) || string.IsNullOrEmpty(Color) || string.IsNullOrEmpty(Categories))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter all fields", "Exit");
                return;
            }

            // HERE WE CONVERT THE IMAGE INTO BYTES TO STORE INTO DATABASE
            var stream = await tempphoto.OpenReadAsync();
            byte[] photoBytes;
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                photoBytes = memoryStream.ToArray();
            }





            var clothes = new Clothes
            {
                Type = Type,
                Color = Color,
                Categories = Categories,
                Source = photoBytes,
                UserID = Username

            };

            await _clothingService.AddClothes(clothes);
            await Shell.Current.DisplayAlert("Nice Taste!", "You Successfully added an clothing item!", "Exit");
            await MopupService.Instance.PopAllAsync();



        }

    }
}

       
        


    
