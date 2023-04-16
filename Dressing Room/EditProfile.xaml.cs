using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Microsoft.Maui.Controls;
using Mopups.Services;

namespace Dressing_Room;

public partial class EditProfile : ContentPage
{
    private EditProfileViewModel viewModel;
    public EditProfile()
    {
        InitializeComponent();

        viewModel = new EditProfileViewModel();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.refresh(); // call ViewModel method to load data
    }
}
