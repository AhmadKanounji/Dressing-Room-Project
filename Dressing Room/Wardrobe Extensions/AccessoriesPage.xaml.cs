
using Dressing_Room.Services;
using Dressing_Room.ViewModels;



namespace Dressing_Room.Wardrobe_Extensions;



public partial class AccessoriesPage : ContentPage

{

    private AccessoriesViewModel viewModel;

    public AccessoriesPage()

    {

        InitializeComponent();

        viewModel = new AccessoriesViewModel();

        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()

    {

        base.OnAppearing();

        viewModel.refresh(); // call ViewModel method to load data

    }

}