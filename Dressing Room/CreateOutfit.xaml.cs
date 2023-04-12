using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class CreateOutfit : ContentPage
{

    private CreateOutfitViewModel viewModel;
    public CreateOutfit()
    {
        InitializeComponent();
        viewModel = new CreateOutfitViewModel();
        this.BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.refreshTops(); // call ViewModel method to load data
        viewModel.refreshPants();
        viewModel.refreshShoes();
        viewModel.refreshJackets();
        viewModel.refreshAccessories();
    }


}