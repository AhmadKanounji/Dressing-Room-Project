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
using static System.Net.Mime.MediaTypeNames;

namespace Dressing_Room.ViewModels
{
    public partial class HomeProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string user_info = Preferences.Get("user_to_display", "default_value");
        [ObservableProperty]
        private int num_outfits = 0;

        [ObservableProperty]
        private int follow_count = 0;
        [ObservableProperty]
        private int following_count = 0;

        [ObservableProperty]
        private string text;
        [ObservableProperty]
        private string color;

        [ObservableProperty]
        private bool followbutton;
        [ObservableProperty]
        private bool unfollowbutton;









        public OutfitsService _outfitsService;
        public SignUpService _signupService;
        public ClothingService _clothingService;
        public FollowService _followService;

        public ObservableCollection<OutfitToDisplay> Outfits { get; }


        public HomeProfileViewModel()
        {

            _outfitsService = new OutfitsService();
            _signupService = new SignUpService();
            _clothingService = new ClothingService();
            _followService = new FollowService();
            Outfits = new ObservableCollection<OutfitToDisplay>();



        }
        [ObservableProperty]
        public byte[] photoSource;


        [RelayCommand]

        public async Task Follow()
        {

            //check if the user follows the visited user:
            var allFollows = await _followService.GetFollows();
            foreach (FollowedTable follows in allFollows)
            {
                if (follows.Follower == Preferences.Get("user_name", "default_value") && follows.Followed == Preferences.Get("user_to_display", "default_value"))
                {
                    Text = "Follow";
                    Followbutton = true;
                    Unfollowbutton = false;

                    await _followService.DeleteFollow(follows.Id);
                    Follow_count = await GetFollowCount(Preferences.Get("user_to_display", "default_value"));


                    return;
                }
            }

            Text = "Unfollow";
            Unfollowbutton = true;
            Followbutton = false;
            // else if the user doesnt follow the visited user:
            var toadd = new FollowedTable
            {
                Follower = Preferences.Get("user_name", "default_value"),
                Followed = Preferences.Get("user_to_display", "Default_value")
            };
            await _followService.AddFollow(toadd);
            Follow_count = await GetFollowCount(Preferences.Get("user_to_display", "default_value"));
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

        public async void RefreshFollowers()
        {
            Follow_count = await GetFollowCount(Preferences.Get("user_to_display", "default_value"));
            Following_count = await GetFollowingCount(Preferences.Get("user_to_display", "default_value"));
            var allFollows = await _followService.GetFollows();
            foreach (FollowedTable follows in allFollows)
            {
                if (follows.Follower == Preferences.Get("user_name", "default_value") && follows.Followed == Preferences.Get("user_to_display", "default_value"))
                {
                    Text = "Unfollow";
                    Followbutton = false;
                    Unfollowbutton = true;
                    return;
                }

            }

            Text = "Follow";
            Color = "#01260A";
            Followbutton = true;
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
