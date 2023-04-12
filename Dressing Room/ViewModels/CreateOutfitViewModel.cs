using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class CreateOutfitViewModel : ObservableObject
    {
        private ClothingService _clothingService;
        public CreateOutfitViewModel()
        {
            _clothingService = new ClothingService();
            Tops = new ObservableCollection<Clothes>();
            Pants = new ObservableCollection<Clothes>();
            Shoes = new ObservableCollection<Clothes>();
            Jackets = new ObservableCollection<Clothes>();
            Accessories = new ObservableCollection<Clothes>();
            refreshTops();
            refreshPants();
            refreshShoes();
            refreshJackets();
            refreshAccessories();


        }
        public ObservableCollection<Clothes> Tops { get; }
        public ObservableCollection<Clothes> Pants { get; }
        public ObservableCollection<Clothes> Shoes { get; }
        public ObservableCollection<Clothes> Jackets { get; }
        public ObservableCollection<Clothes> Accessories { get; }



        public async void refreshTops()
        {
            var allClothes = await _clothingService.GetClothes();
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
                        CID = clothes.CID

                    }); ;
                }
            }
        }

        public async void refreshPants()
        {
            var allClothes = await _clothingService.GetClothes();
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
                        CID = clothes.CID

                    }); ;
                }
            }
        }

        public async void refreshShoes()
        {
            var allClothes = await _clothingService.GetClothes();
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
                        CID = clothes.CID

                    }); ;
                }
            }
        }

        public async void refreshJackets()
        {
            var allClothes = await _clothingService.GetClothes();
            Jackets.Clear();
            foreach (var clothes in allClothes)
            {
                if (clothes.Categories == "Jackets")

                {


                    Jackets.Add(new Clothes
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

        public async void refreshAccessories()
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
    }
}
