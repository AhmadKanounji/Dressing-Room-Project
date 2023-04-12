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

    public partial class AccessoriesViewModel : ObservableObject

    {

        private ClothingService _clothingService;



        public AccessoriesViewModel()

        {

            _clothingService = new ClothingService();



            Accessories = new ObservableCollection<Clothes>();

            refresh();

        }



        public ObservableCollection<Clothes> Accessories { get; }











        public async void refresh()

        {

            var allClothes = await _clothingService.GetClothes();

            Accessories.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Accessories")



                {





                    Accessories.Add(new Clothes

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



        [RelayCommand]

        async Task GetAccessories()

        {



            var allClothes = await _clothingService.GetClothes();



            Accessories.Clear();

            foreach (var clothes in allClothes)

            {

                if (clothes.Categories == "Accessories")



                {

                    //CONVERTING BYTE BACK TO IMAGE SOURCE

                    //byte[] imageData = clothes.Source;

                    //ImageSource imageSource;



                    //using (MemoryStream ms = new MemoryStream(imageData))

                    //{

                    //    imageSource = ImageSource.FromStream(() => ms);

                    //}



                    Accessories.Add(new Clothes

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

