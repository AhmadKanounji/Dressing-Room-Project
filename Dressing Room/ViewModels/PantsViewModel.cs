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

    public partial class PantsViewModel : ObservableObject

    {

        private ClothingService _clothingService;
        private OutfitsService _outfitsService;



        public PantsViewModel()

        {

            _clothingService = new ClothingService();
            _outfitsService = new OutfitsService();



            Pants = new ObservableCollection<Clothes>();

            refresh();

        }



        public ObservableCollection<Clothes> Pants { get; }




        private Command<Clothes> _deletePantsCommand;
        public Command<Clothes> DeletePantsCommand => _deletePantsCommand ??= new Command<Clothes>(async (pants) =>
        {

            var outfits = await _outfitsService.GetOutfits();
            foreach (Outfits o in outfits)
            {
                if (o.PantsID == pants.CID)
                {
                    await _outfitsService.DdeleteOutfits(o.Id);

                }
            }

            await _clothingService.DdeleteClothes(pants.CID);
            WeakReferenceMessenger.Default.Send(new RefreshOutfitMessage(null));

            refresh();





        });






        public async void refresh()

        {

            var Current_User = Preferences.Get("user_name", "default_value");
            var allClothes = await _clothingService.GetSpecificClothes(Current_User);

            Pants.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Pants")



                {





                    Pants.Add(new Clothes

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

        async Task GetPants()

        {



            var allClothes = await _clothingService.GetClothes();



            Pants.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Pants")



                {

                    //CONVERTING BYTE BACK TO IMAGE SOURCE

                    //byte[] imageData = clothes.Source;

                    //ImageSource imageSource;



                    //using (MemoryStream ms = new MemoryStream(imageData))

                    //{

                    //    imageSource = ImageSource.FromStream(() => ms);

                    //}



                    Pants.Add(new Clothes

                    {

                        Categories = clothes.Categories,

                        Color = clothes.Color,

                        Source = clothes.Source,

                        Type = clothes.Type,

                        CID = clothes.CID,




                    }); ;

                }

            }

        }



    }

}