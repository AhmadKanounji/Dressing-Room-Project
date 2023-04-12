
using Dressing_Room.Services;

using Dressing_Room.ViewModels;



namespace Dressing_Room.Wardrobe_Extensions;



public partial class PantsPage : ContentPage

{

    private PantsViewModel viewModel;

    public PantsPage()

    {

        InitializeComponent();

        viewModel = new PantsViewModel();

        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()

    {

        base.OnAppearing();

        viewModel.refresh(); // call ViewModel method to load data

    }

}