using Dressing_Room.Services;

using Dressing_Room.ViewModels;



namespace Dressing_Room.Wardrobe_Extensions;



public partial class ShoesPage : ContentPage

{

    private ShoesViewModel viewModel;

    public ShoesPage()

    {

        InitializeComponent();

        viewModel = new ShoesViewModel();

        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()

    {

        base.OnAppearing();

        viewModel.refresh(); // call ViewModel method to load data

    }

}