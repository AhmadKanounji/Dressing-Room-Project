using CommunityToolkit.Maui.Behaviors;
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
    public partial class TopsViewModel : ObservableObject
    {
        private ClothingService _clothingService;
        private OutfitsService _outfitsService;
        private OufitViewModel _OutfitViewModel;

        public TopsViewModel()
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
            _OutfitViewModel = new OufitViewModel();
            Tops = new ObservableCollection<Clothes>();

            refresh();
        }

        public ObservableCollection<Clothes> Tops { get; }



        private Command<Clothes> _deleteTopCommand;
        public Command<Clothes> DeleteTopCommand => _deleteTopCommand ??= new Command<Clothes>(async (top) =>
        {
            var outfits = await _outfitsService.GetOutfits();
            foreach (Outfits o in outfits)
            {
                if (o.TopID == top.CID)
                {
                    await _outfitsService.DdeleteOutfits(o.Id);

                }
            }

            await _clothingService.DdeleteClothes(top.CID);
            WeakReferenceMessenger.Default.Send(new RefreshOutfitMessage(null));




            refresh();
        });



        public async void refresh()
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

        [RelayCommand]
        async Task GetTops()
        {

            var allClothes = await _clothingService.GetClothes();

            Tops.Clear();
            foreach (var clothes in allClothes)
            {
                if (clothes.Categories == "Tops")

                {
                    //CONVERTING BYTE BACK TO IMAGE SOURCE 
                    //byte[] imageData = clothes.Source;
                    //ImageSource imageSource;

                    //using (MemoryStream ms = new MemoryStream(imageData))
                    //{
                    //    imageSource = ImageSource.FromStream(() => ms);
                    //}

                    Tops.Add(new Clothes
                    {
                        Categories = clothes.Categories,
                        Color = clothes.Color,
                        Source = clothes.Source,
                        Type = clothes.Type,
                        CID = clothes.CID

                    }); ;
                }
            }
        }




    }
}
