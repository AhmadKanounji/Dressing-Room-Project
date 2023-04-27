using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class GenerateWeather : ContentPage
{
    private GenerateWeatherViewModel viewModel;

    public GenerateWeather()
    {
        InitializeComponent();

        viewModel = new GenerateWeatherViewModel();
        this.BindingContext = viewModel;
    }


}