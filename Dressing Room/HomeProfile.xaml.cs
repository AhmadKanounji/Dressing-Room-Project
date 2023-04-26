using Dressing_Room.ViewModels;
using Mopups.Services;

namespace Dressing_Room;

public partial class HomeProfile
{
    private HomeProfileViewModel viewModel;
    public HomeProfile()
    {
        InitializeComponent();
        viewModel = new HomeProfileViewModel();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Task.Delay(2000);
        viewModel.refresh(); // call ViewModel method to load data
        viewModel.RefreshOutfitsNumber();
        viewModel.Refresh();
    }

}