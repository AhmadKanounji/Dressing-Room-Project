using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.Models;
using Dressing_Room.Services;
using Mopups.Services;

namespace Dressing_Room.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string user_info = Preferences.Get("user_name", "default_value");
        [ObservableProperty]
        private int num_outfits = 0;
        [ObservableProperty]
        private int follow_count = 0;
        [ObservableProperty]
        private int following_count = 0;

        [RelayCommand]
        async void GoToEditProfile()
        {
            await MopupService.Instance.PushAsync(new RemoveBugPopup());
            Routing.RegisterRoute(nameof(EditProfile), typeof(EditProfile));
            await Shell.Current.GoToAsync(nameof(EditProfile));
        }







        public SignUpService _signUpService;
        public OutfitsService _outfitsService;
        public FollowService _followService;
        public ClothingService _clothingService;




        public ProfileViewModel()
        {
            _signUpService = new SignUpService();
            _outfitsService = new OutfitsService();
            _followService = new FollowService();
            _clothingService = new ClothingService();
            Outfits = new ObservableCollection<OutfitToDisplay>();

            refresh();

        }
        public ObservableCollection<OutfitToDisplay> Outfits { get; }


        [ObservableProperty]
        public byte[] photoSource;


        public async void refresh()
        {

            var allUsers = await _signUpService.GetUser();
            foreach (var user in allUsers)
            {
                if (user.Username == Preferences.Get("user_name", "deafault_value"))
                {
                    PhotoSource = user.Source;
                    break;
                }

            }


        }
        public async Task<int> GetFollowCount(string username)
        {
            int count = 0;
            var allFollows = await _followService.GetFollows();
            foreach (FollowedTable follows in allFollows)
            {
                if (follows.Followed == username) count++;



            }
            return count;
        }
        public async Task<int> GetFollowingCount(string username)
        {
            int count = 0;
            var allFollows = await _followService.GetFollows();
            foreach (FollowedTable follows in allFollows)
            {
                if (follows.Follower == username) count++;



            }
            return count;
        }


        public async void RefreshOutfitsNumber()
        {
            var allOutfits = await _outfitsService.GetOutfits();
            foreach (Outfits outfit in allOutfits)
            {
                if (outfit.UserID == User_info) Num_outfits++;
            }
        }

        public async void Refresh()
        {


            var alloutfits = await _outfitsService.GetSpecificOutfits(Preferences.Get("user_name", "default_value"));

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
                toadd.UserName = Preferences.Get("user_name", "default_value");
                toadd.ProfilePhoto = outfit.ProfilePhoto;
                Outfits.Add(toadd);


            }

            Follow_count = await GetFollowCount(Preferences.Get("user_name", "default_value"));
            Following_count = await GetFollowingCount(Preferences.Get("user_name", "default_value"));

        }
    }
}
