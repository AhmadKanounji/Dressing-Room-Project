using CommunityToolkit.Mvvm.ComponentModel;
using Dressing_Room.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room.ViewModels
{
    public partial class ClothViewModel : ObservableObject
    {
        
        public ClothViewModel()
        {
           
        }
   


        [ObservableProperty]
        private string type;
        [ObservableProperty]

        private string color;
        [ObservableProperty]
        private string categories;
        
        

    }
}
