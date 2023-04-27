using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;

namespace Dressing_Room;

public partial class OutfitsPage : ContentPage
{
    private OufitViewModel viewModel;
    public OutfitsPage()
    {
        InitializeComponent();
        viewModel = new OufitViewModel();
        this.BindingContext = viewModel;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
       
    }
}