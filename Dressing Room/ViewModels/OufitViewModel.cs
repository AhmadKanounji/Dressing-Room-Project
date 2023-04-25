using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class OufitViewModel : ObservableObject, IRecipient<RefreshOutfitMessage>
    {
        private OutfitsService _outfitService;
        private ClothingService _clothingService;
        private ProfileViewModel _profileViewModel;
        public OufitViewModel()
        {
            _outfitService = new OutfitsService();
            _clothingService = new ClothingService();
            WeakReferenceMessenger.Default.Register<RefreshOutfitMessage>(this);
            Outfits = new ObservableCollection<OutfitToDisplay>();
            Refresh();
        }




        public ObservableCollection<OutfitToDisplay> Outfits { get; }

        private Command<OutfitToDisplay> _deleteOutfitCommand;
        public Command<OutfitToDisplay> DeleteOutfitCommand => _deleteOutfitCommand ??= new Command<OutfitToDisplay>(async (outfit) =>
        {
            await _outfitService.DdeleteOutfits(outfit.Id);
            Refresh();
            await Task.Delay(500);
        });
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
                if (outfit.UserID == Preferences.Get("user_name", "default_value"))
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

                    toadd.Id = outfit.Id;
                    Outfits.Add(toadd);

                }
            }

        }

    }
}
