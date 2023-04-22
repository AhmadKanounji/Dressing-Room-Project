using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public CreateOutfitViewModel()
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
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

        public async Task<Outfits> GenerateOutfitAsync(Clothes selectedTop, Clothes selectedPants, Clothes selectedJacket, Clothes selectedShoes, Clothes selectedAccessories)
        {
            // Create a new Outfit object
            var outfit = new Outfits();

            // Set the Top and Pants properties of the outfit
            outfit.TopID = selectedTop.CID;
            outfit.PantsID = selectedPants.CID;
            outfit.JacketID = selectedJacket.CID;
            outfit.ShoesID = selectedShoes.CID;
            outfit.AccessoriesID = selectedAccessories.CID;

            return outfit;
        }

        private Clothes _selectedTop;
        public Clothes SelectedTop
        {
            get => _selectedTop;
            set => SetProperty(ref _selectedTop, value);
        }

        private Clothes _selectedPants;
        public Clothes SelectedPants
        {
            get => _selectedPants;
            set => SetProperty(ref _selectedPants, value);
        }

        private Clothes _selectedJacket;
        public Clothes SelectedJacket
        {
            get => _selectedJacket;
            set => SetProperty(ref _selectedJacket, value);
        }

        private Clothes _selectedShoes;
        public Clothes SelectedShoes
        {
            get => _selectedShoes;
            set => SetProperty(ref _selectedShoes, value);
        }
        private Clothes _selectedAccessories;
        public Clothes SelectedAccessories
        {
            get => _selectedAccessories;
            set => SetProperty(ref _selectedAccessories, value);
        }

        [RelayCommand]
        public async Task CreateOutfitAsync()
        {
            // Call the GenerateOutfitAsync method passing in the selected clothes
            var outfit = await GenerateOutfitAsync(SelectedTop, SelectedPants, SelectedJacket, SelectedShoes, SelectedAccessories);
            await _outfitsService.AddOutfits(outfit);


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
