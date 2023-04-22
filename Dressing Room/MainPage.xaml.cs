using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel mainpagevm)
    {
        InitializeComponent();
        this.BindingContext = mainpagevm;
    }
}