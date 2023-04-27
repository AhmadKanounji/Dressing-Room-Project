using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Dressing_Room.Messages;
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
    public partial class HomePageViewModel : ObservableObject, IRecipient<RefreshOutfitMessage>
    {
        private OutfitsService _outfitService;
        private ClothingService _clothingService;
        private SignUpService _signupService;
        public HomePageViewModel()
        {
            _outfitService = new OutfitsService();
            _clothingService = new ClothingService();
            _signupService = new SignUpService();
            WeakReferenceMessenger.Default.Register<RefreshOutfitMessage>(this);
            Outfits = new ObservableCollection<OutfitToDisplay>();


            Users = new ObservableCollection<User>();
            Refresh();


        }

        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private bool outfitlist = true;
        [ObservableProperty]
        private bool userlist = false;


        private Command<OutfitToDisplay> _gotohomeprofile;
        public Command<OutfitToDisplay> GoToHomeProfileCommand => _gotohomeprofile ??= new Command<OutfitToDisplay>(async (outfit) =>
        {

            Preferences.Set("user_to_display", outfit.UserName);

            await MopupService.Instance.PushAsync(new HomeProfile());

        });

        private Command<User> _gotohomeprofile2;
        public Command<User> GoToHomeProfileCommand2 => _gotohomeprofile2 ??= new Command<User>(async (user) =>
        {

            Preferences.Set("user_to_display", user.Username);

            await MopupService.Instance.PushAsync(new HomeProfile());

        });


        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<OutfitToDisplay> Outfits { get; set; }
        public ObservableCollection<User> FilteredUsers { get; set; }

        public void Receive(RefreshOutfitMessage message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Refresh();
            });
        }

        public async void Refresh()
        {
            var alloutfits = await _outfitService.GetOutfits();
            Outfits.Clear();
            foreach (Outfits outfit in alloutfits)
            {
                if (outfit.UserID != Preferences.Get("user_name", "default_value"))


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
                    toadd.UserName = outfit.UserID;
                    toadd.ProfilePhoto = outfit.ProfilePhoto;
                    Outfits.Add(toadd);

                }
            }

        }



        public async Task RefreshUsers(string searchTerm = "")
        {
            var allUsers = await _signupService.GetUser();
            var filteredUsers = allUsers.Where(u => u.Username.StartsWith(searchTerm, StringComparison.InvariantCultureIgnoreCase));
            Users.Clear();
            foreach (User user in filteredUsers)
            {
                if (user.Username != Preferences.Get("user_name", "default_value"))
                {
                    Users.Add(user);
                }

            }
        }







    }
}
