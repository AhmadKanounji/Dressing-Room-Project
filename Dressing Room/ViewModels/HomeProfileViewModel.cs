using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.ViewModels
{
    public partial class HomeProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string user_info = Preferences.Get("user_to_display", "default_value");
        [ObservableProperty]
        private int num_outfits = 0;









        public OutfitsService _outfitsService;
        public SignUpService _signupService;
        public ClothingService _clothingService;

        public ObservableCollection<OutfitToDisplay> Outfits { get; }


        public HomeProfileViewModel()
        {

            _outfitsService = new OutfitsService();
            _signupService = new SignUpService();
            _clothingService = new ClothingService();
            Outfits = new ObservableCollection<OutfitToDisplay>();



        }
        [ObservableProperty]
        public byte[] photoSource;


        public async void refresh()
        {

            var allUsers = await _signupService.GetUser();
            foreach (var user in allUsers)
            {
                if (user.Username == Preferences.Get("user_to_display", "deafault_value"))
                {
                    PhotoSource = user.Source;
                    break;
                }

            }


        }

        public async void RefreshOutfitsNumber()
        {
            var allOutfits = await _outfitsService.GetOutfits();
            foreach (Outfits outfit in allOutfits)
            {
                if (outfit.UserID == Preferences.Get("user_to_display", "default_value")) Num_outfits++;
            }
        }
        public async void Refresh()
        {


            var alloutfits = await _outfitsService.GetSpecificOutfits(Preferences.Get("user_to_display", "default_value"));

            Outfits.Clear();

            foreach (Outfits outfit in alloutfits)
            {



                //Create an OutfitToAdd and loop through all the clothes. If we find clothes ID matching to one of the outfits ID then we add to Outfit to display.
                // Once we are done with all the clothes then we should have a complete outfit. So we exit the forloop and add the outfit to the Observable Collection,
                //Then, we repeat the process with the other outfits
                var allClothes = await _clothingService.GetClothes();
                var toadd = new OutfitToDisplay();
                foreach (Clothes clothes in allClothes)
                {

                    if (clothes.CID == outfit.TopID)
                    {
                        toadd.Tops = clothes.Source;
                    }
                    if (clothes.CID == outfit.PantsID)
                    {
                        toadd.Pants = clothes.Source;

                    }

                    if (clothes.CID == outfit.ShoesID)
                    {
                        toadd.Shoes = clothes.Source;

                    }
                    if (clothes.CID == outfit.JacketID)
                    {
                        toadd.Jackets = clothes.Source;


                    }
                    if (clothes.CID == outfit.AccessoriesID)
                    {
                        toadd.Accessories = clothes.Source;

                    }



                }
                toadd.UserName = Preferences.Get("user_to_display", "default_value");
                toadd.ProfilePhoto = outfit.ProfilePhoto;
                Outfits.Add(toadd);


            }

        }

    }
}

