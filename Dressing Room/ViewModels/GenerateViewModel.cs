using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Services;
using Dressing_Room.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Google.Crypto.Tink.Integration.Android;

namespace Dressing_Room.ViewModels
{
    public partial class GenerateViewModel : ObservableObject
    {
        private ClothingService _clothingService;
        private OutfitsService _outfitsService;
        public GenerateViewModel()
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
            outfit = new ObservableCollection<OutfitToDisplay>();
        }
        [ObservableProperty]
        private string topColorr;
        [ObservableProperty]
        private string pantColorr;
        [ObservableProperty]
        private string jacketColorr;
        [ObservableProperty]
        private string accessorieColorr;
        [ObservableProperty]
        private string shoeColorr;

        [ObservableProperty]
        private bool show;

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
        async Task generateOutfit()
        {

            outfit.Clear();

            var tops = await _clothingService.GetClothesByColor(TopColorr, "Tops");
            var pants = await _clothingService.GetClothesByColor(PantColorr, "Pants");
            var jackets = await _clothingService.GetClothesByColor(JacketColorr, "Shoes");
            var accessories = await _clothingService.GetClothesByColor(AccessorieColorr, "Jackets");
            var shoes = await _clothingService.GetClothesByColor(ShoeColorr, "Accessories");



            var randomTop = tops.ElementAtOrDefault(new Random().Next(0, tops.Count));
            var randomPant = pants.ElementAtOrDefault(new Random().Next(0, pants.Count));
            var randomShoe = shoes.ElementAtOrDefault(new Random().Next(0, shoes.Count));
            var randomJacket = jackets.ElementAtOrDefault(new Random().Next(0, jackets.Count));
            var randomAccessorie = accessories.ElementAtOrDefault(new Random().Next(0, accessories.Count));



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
