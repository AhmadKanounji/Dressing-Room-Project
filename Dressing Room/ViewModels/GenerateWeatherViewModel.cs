using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Dressing_Room.Messages;
using Dressing_Room.Models;
using Dressing_Room.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.ViewModels
{
    public partial class GenerateWeatherViewModel : ObservableObject
    {

        private ClothingService _clothingService;
        private OutfitsService _outfitsService;
        private readonly WeatherData _weatherdata;

        public GenerateWeatherViewModel(WeatherData weatherData)
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
            _weatherdata = weatherData;
            outfit = new ObservableCollection<OutfitToDisplay>();
        }



        private double _temperature;

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        [ObservableProperty]
        private bool show;

        [ObservableProperty]
        private string city;

        public ObservableCollection<OutfitToDisplay> outfit { get; }

        public Outfits savedOutfit = new Outfits();


        public async Task No()
        {
            outfit.Clear();
            Show = false;
        }

        public async Task addOutfit()
        {
            Show = false;
            outfit.Clear();
            await Shell.Current.DisplayAlert("Success!", "New Outfit Created!", "Exit");
            await _outfitsService.AddOutfits(savedOutfit);
            WeakReferenceMessenger.Default.Send(new RefreshOutfitMessage(null));
        }




        public async Task GenerateOutfit()
        {

            outfit.Clear();
            double temp = _weatherdata.Main.Temperature;

            temp = (temp - 30) / 2;
            List<Clothes> selectedTop = new List<Clothes>();
            List<Clothes> selectedPants = new List<Clothes>();
            List<Clothes> selectedJackets = new List<Clothes>();
            List<Clothes> selectedShoes = new List<Clothes>();
            List<Clothes> selectedAccessories = new List<Clothes>();




            var clothes = await _clothingService.GetClothes();

            if (temp > 24)
            {
                foreach (Clothes top in clothes)
                {
                    if (top.Categories == "Tops" && (top.Type == "T-Shirt" || top.Type == "Tank Top" || top.Type == "Crop Top" || top.Type == "Halter Top" || top.Type == "Camisole"))
                    {
                        selectedTop.Add(top);
                    }
                    if (top.Categories == "Pants")
                    {
                        selectedPants.Add(top);
                    }
                    if (top.Categories == "Shoes" && top.Type != "Boots")
                    {
                        selectedShoes.Add(top);
                    }
                    if (top.Categories == "Jackets" && (top.Type == "Denim Jacket" || top.Type == "Blazer"))
                    {
                        selectedJackets.Add(top);
                    }
                    if (top.Categories == "Accessories" && top.Type != "Scarf")
                    {
                        selectedAccessories.Add(top);
                    }
                }
            }
            else
            {
                foreach (Clothes top in clothes)
                {
                    if (top.Categories == "Tops" && (top.Type != "T-Shirt" || top.Type != "Tank Top" || top.Type != "Crop Top" || top.Type != "Halter Top" || top.Type != "Camisole"))
                    {
                        selectedTop.Add(top);
                    }
                    if (top.Categories == "Pants")
                    {
                        selectedPants.Add(top);
                    }
                    if (top.Categories == "Shoes" && top.Type == "Boots")
                    {
                        selectedShoes.Add(top);
                    }
                    if (top.Categories == "Jackets" && (top.Type != "Denim Jacket" || top.Type != "Blazer"))
                    {
                        selectedJackets.Add(top);
                    }
                    if (top.Categories == "Accessories" && top.Type == "Scarf")
                    {
                        selectedAccessories.Add(top);
                    }
                }
            }

            var randomTop = selectedTop.ElementAtOrDefault(new Random().Next(0, selectedTop.Count));
            var randomPant = selectedPants.ElementAtOrDefault(new Random().Next(0, selectedPants.Count));
            var randomShoe = selectedShoes.ElementAtOrDefault(new Random().Next(0, selectedShoes.Count));
            var randomJacket = selectedJackets.ElementAtOrDefault(new Random().Next(0, selectedJackets.Count));
            var randomAccessorie = selectedAccessories.ElementAtOrDefault(new Random().Next(0, selectedAccessories.Count));


            var o = new OutfitToDisplay
            {
                Tops = randomTop.Source,
                Pants = randomPant.Source,
                Shoes = randomShoe.Source,
                Jackets = randomJacket.Source,
                Accessories = randomAccessorie.Source,
                UserName = Preferences.Get("user_name", "default_value")
            };


            outfit.Add(o);
            savedOutfit.TopID = randomTop.CID;
            savedOutfit.PantsID = randomPant.CID;

            savedOutfit.ShoesID = randomShoe.CID;

            savedOutfit.JacketID = randomJacket.CID;

            savedOutfit.AccessoriesID = randomAccessorie.CID;
            savedOutfit.UserID = Preferences.Get("user_name", "default_value");





            Show = true;



        }

    }


}
