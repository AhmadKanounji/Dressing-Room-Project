using Dressing_Room.Models;
using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;
using Mopups.Services;
using System.Collections.ObjectModel;

namespace Dressing_Room;

public partial class HomePage : ContentPage
{
    private HomePageViewModel viewModel;
    public HomePage()
    {
        InitializeComponent();
        viewModel = new HomePageViewModel();
        this.BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // call ViewModel method to load data
        await viewModel.RefreshUsers();

    }



    private async void Kano_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchitem = Kano.Text;
        if (string.IsNullOrWhiteSpace(searchitem))
        {
            viewModel.Outfitlist = true;
            viewModel.Userlist = false;
        }
        else
        {
            viewModel.Outfitlist = false;
            viewModel.Userlist = true;
            await viewModel.RefreshUsers(searchitem);
        }

    }
}