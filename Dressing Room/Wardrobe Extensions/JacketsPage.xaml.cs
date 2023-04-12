
using Dressing_Room.Services;

using Dressing_Room.ViewModels;



namespace Dressing_Room.Wardrobe_Extensions;



public partial class JacketsPage : ContentPage

{

    private JacketsViewModel viewModel;

    public JacketsPage()

    {

        InitializeComponent();

        viewModel = new JacketsViewModel();

        this.BindingContext = viewModel;

    }

    protected override void OnAppearing()

    {

        base.OnAppearing();

        viewModel.refresh(); // call ViewModel method to load data

    }

}