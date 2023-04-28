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

    public partial class ShoesViewModel : ObservableObject
    {
        private ClothingService _clothingService;
        private OutfitsService _outfitsService;

        public ShoesViewModel()
        {
            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();
            Shoes = new ObservableCollection<Clothes>();
            refresh();

        }

        public ObservableCollection<Clothes> Shoes { get; }

        private Command<Clothes> _deleteShoesCommand;
        public Command<Clothes> DeleteShoesCommand => _deleteShoesCommand ??= new Command<Clothes>(async (shoes) =>
        {

            var outfits = await _outfitsService.GetOutfits();
            foreach (Outfits o in outfits)
            {
                if (o.ShoesID == shoes.CID)
                {
                    await _outfitsService.DdeleteOutfits(o.Id);

                }
            }

            await _clothingService.DdeleteClothes(shoes.CID);
            WeakReferenceMessenger.Default.Send(new RefreshOutfitMessage(null));

            refresh();
        });

        public async void refresh()
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



        [RelayCommand]

        async Task GetShoes()

        {



            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);



            Shoes.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Shoes")



                {

                    //CONVERTING BYTE BACK TO IMAGE SOURCE

                    //byte[] imageData = clothes.Source;

                    //ImageSource imageSource;



                    //using (MemoryStream ms = new MemoryStream(imageData))

                    //{

                    //    imageSource = ImageSource.FromStream(() => ms);

                    //}



                    Shoes.Add(new Clothes

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