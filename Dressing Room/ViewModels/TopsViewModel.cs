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
    public partial class TopsViewModel:ObservableObject
    {
        private ClothingService _clothingService;
        
        public TopsViewModel() 
        { 
            _clothingService = new ClothingService();
        }

        public ObservableCollection<Clothes> Tops { get; } = new ObservableCollection<Clothes>();

        


        [RelayCommand]
        async Task GetTops()
        {

            var allClothes =await _clothingService.GetClothes();

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
                        
                    });;
                }
            }
        }

    }
}
