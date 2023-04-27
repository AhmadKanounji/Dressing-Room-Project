using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Dressing_Room.Messages;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.ViewModels
{
    public partial class CreateOutfitViewModel : ObservableObject
    {
        private ClothingService _clothingService;
        private OutfitsService _outfitsService;
        private SignUpService _signUpService;
        public CreateOutfitViewModel()
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
            _signUpService = new SignUpService();
            Tops = new ObservableCollection<Clothes>();
            Pants = new ObservableCollection<Clothes>();
            Shoes = new ObservableCollection<Clothes>();
            Jackets = new ObservableCollection<Clothes>();
            Accessories = new ObservableCollection<Clothes>();
            refreshTops();
            refreshPants();
            refreshShoes();
            refreshJackets();
            refreshAccessories();


        }
        public ObservableCollection<Clothes> Tops { get; }
        public ObservableCollection<Clothes> Pants { get; }
        public ObservableCollection<Clothes> Shoes { get; }
        public ObservableCollection<Clothes> Jackets { get; }
        public ObservableCollection<Clothes> Accessories { get; }



        [ObservableProperty]
        private Clothes selectedTop;

        [ObservableProperty]
        public Clothes selectedPants;

        [ObservableProperty]
        public Clothes selectedJacket;

        [ObservableProperty]
        public Clothes selectedShoes;


        [ObservableProperty]
        public Clothes selectedAccessories;

        byte[] profile;


        [RelayCommand]
        public async Task CreateOutfitAsync()
        {
            if (SelectedTop == null || SelectedPants == null | SelectedShoes == null || SelectedJacket == null || SelectedAccessories == null)
            {
                await Shell.Current.DisplayAlert("Oops", "Please select all clothing types", "Exit");
                return;
            }
            await Shell.Current.DisplayAlert("hello", "hi", "hello");
            var allUsers = await _signUpService.GetUser();

            await Shell.Current.DisplayAlert("hello", "hi", "hello");
            foreach (var user in allUsers)
            {
                if (user.Username == Preferences.Get("user_name", "default_value"))
                {
                    if (user.Source == null)
                    {
                        await Shell.Current.DisplayAlert("hello", "hi", "hello");
                    }
                    else
                    {
                        profile = user.Source;
                        break;
                    }


                }
            }
            await Shell.Current.DisplayAlert("hi", "hi", "hi");
            // Call the GenerateOutfitAsync method passing in the selected clothes
            var outfit = new Outfits
            {
                TopID = SelectedTop.CID,
                PantsID = SelectedPants.CID,
                ShoesID = SelectedShoes.CID,
                JacketID = SelectedJacket.CID,
                AccessoriesID = SelectedAccessories.CID,
                UserID = Preferences.Get("user_name", "default_value"),
                Likes = 0,
                ProfilePhoto = profile

            };
            await _outfitsService.AddOutfits(outfit);
            WeakReferenceMessenger.Default.Send(new RefreshOutfitMessage(null));


            // Do something with the created outfit, such as saving it to a database or displaying it on the UI
            await Shell.Current.DisplayAlert("Uh Oh", "Outfit created succesfully.", "Exit");
        }


        public async void refreshTops()
        {
            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);
            Tops.Clear();
            foreach (var clothes in allClothes)
            {
                if (clothes.Categories == "Tops")

                {


                    Tops.Add(new Clothes
                    {
                        Categories = clothes.Categories,
                        Color = clothes.Color,
                        Source = clothes.Source,
                        Type = clothes.Type,
                        CID = clothes.CID,
                        UserID = Current_User


                    }); ;
                }
            }
        }

        public async void refreshPants()
        {

            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);

            Pants.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Pants")



                {





                    Pants.Add(new Clothes

                    {

                        Categories = clothes.Categories,

                        Color = clothes.Color,

                        Source = clothes.Source,

                        Type = clothes.Type,

                        CID = clothes.CID,
                        UserID = Current_User



                    }); ;

                }

            }
        }

        public async void refreshShoes()
        {
            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);

            Shoes.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Shoes")



                {





                    Shoes.Add(new Clothes

                    {

                        Categories = clothes.Categories,

                        Color = clothes.Color,

                        Source = clothes.Source,

                        Type = clothes.Type,

                        CID = clothes.CID,
                        UserID = Current_User




                    }); ;

                }

            }
        }

        public async void refreshJackets()
        {
            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);
            Jackets.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Jackets")



                {





                    Jackets.Add(new Clothes

                    {

                        Categories = clothes.Categories,

                        Color = clothes.Color,

                        Source = clothes.Source,

                        Type = clothes.Type,

                        CID = clothes.CID,
                        UserID = Current_User



                    }); ;

                }

            }
        }

        public async void refreshAccessories()
        {
            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);

            Accessories.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Accessories")



                {





                    Accessories.Add(new Clothes

                    {

                        Categories = clothes.Categories,

                        Color = clothes.Color,

                        Source = clothes.Source,

                        Type = clothes.Type,

                        CID = clothes.CID,
                        UserID = Current_User



                    }); ;

                }

            }
        }

    }
}