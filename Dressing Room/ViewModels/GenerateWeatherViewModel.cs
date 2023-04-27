using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private RestService _restService;
        private ClothingService _clothingService;
        private OutfitsService _outfitsService;

        public GenerateWeatherViewModel()
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
            _restService = new RestService();
            outfit = new ObservableCollection<OutfitToDisplay>();
        }

        public WeatherData weatherdata;

        [ObservableProperty]
        private double temp;

        [ObservableProperty]
        private bool show;

        [ObservableProperty]
        private string city;

        public ObservableCollection<OutfitToDisplay> outfit { get; }

        public Outfits savedOutfit = new Outfits();


        [RelayCommand]
        async Task No()
        {
            outfit.Clear();
            Show = false;
        }
        [RelayCommand]
        async Task addOutfit()
        {
            Show = false;
            outfit.Clear();
            await Shell.Current.DisplayAlert("Success!", "New Outfit Created!", "Exit");
            await _outfitsService.AddOutfits(savedOutfit);


        }



        [RelayCommand]
        async Task GenerateOutfit()
        {
            outfit.Clear();
            await Shell.Current.DisplayAlert(City, weatherdata.Main.Temperature.ToString(), "hi");
            if (!string.IsNullOrWhiteSpace(City))
            {
                weatherdata = await _restService.GetWeatherData(GenerateRequestURL(Constants.OpenWeatherMapEndpoint));
                await Shell.Current.DisplayAlert(City, weatherdata.Main.Temperature.ToString(), "hi");
            }
            Temp = weatherdata.Main.Temperature;
            Temp = (Temp - 30) / 2;
            List<Clothes> selectedTop = new List<Clothes>();
            List<Clothes> selectedPants = new List<Clothes>();
            List<Clothes> selectedJackets = new List<Clothes>();
            List<Clothes> selectedShoes = new List<Clothes>();
            List<Clothes> selectedAccessories = new List<Clothes>();




            var clothes = await _clothingService.GetClothes();
            if (Temp > 24)
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
        string GenerateRequestURL(string endPoint)
        {
            string requestUri = endPoint;
            requestUri += $"?q={"Beirut"}";
            requestUri += "&units=imperial";
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }

}
