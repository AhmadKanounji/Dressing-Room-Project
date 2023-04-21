
using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;
using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpAdd
{

    public PopUpAdd()
    {
        InitializeComponent();
        ClothingService clothingService = new ClothingService();
        BindingContext = new ClothViewModel(clothingService);

    }

    string[] tops_type = { "T-Shirt", "Tank Top", "Blouse", "Button-Down shirt", "Hoodie", "Sweater", "Crop Top", "Camisole", "Cardigan", "Halter Top" };
    string[] pants_type = { "Jeans", "Leggings", "Trousers", "Shorts", "Skirts", "Cargo Pants" };
    string[] shoes_type = { "Sneakers", "Flats", "Sandals", "Boots", "Heels" };
    string[] jackets_type = { "Denim Jacket", "Bomber Jacket", "Leather Jacket", "Coat", "Blazer", "Puffer Jacket" };
    string[] accessories_type = { "Jewelery", "Watch", "Sunglasses", "Hat", "Scarf", "Handbag", "Belt", "Ties" };


    void myCategory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {

        var picker = (BorderlessPicker)sender;

        var selectedCategory = (string)picker.SelectedItem;

        myType.IsVisible = true;
        myBorder.IsVisible = true;

        if (selectedCategory == "Tops") myType.ItemsSource = tops_type;
        if (selectedCategory == "Pants") myType.ItemsSource = pants_type;
        if (selectedCategory == "Shoes") myType.ItemsSource = shoes_type;
        if (selectedCategory == "Jackets") myType.ItemsSource = jackets_type;
        if (selectedCategory == "Accessories") myType.ItemsSource = accessories_type;

    }

}





