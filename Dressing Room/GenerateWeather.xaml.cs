using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class GenerateWeather : ContentPage
{
    private RestService _restService;
    private GenerateWeatherViewModel viewModel;
    public GenerateWeather()
    {
        InitializeComponent();
        _restService = new RestService();

    }



    async void OnGetWeatherButtonClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
        {
            WeatherData weatherdata = await _restService.GetWeatherData(GenerateRequestURL(Constants.OpenWeatherMapEndpoint));


            viewModel = new GenerateWeatherViewModel(weatherdata);
            viewModel.Temperature = weatherdata.Main.Temperature;
            await viewModel.GenerateOutfit();
            BindingContext = viewModel;
        }

    }

    async void clicked(object sender, EventArgs e)
    {
        await viewModel.No();

    }
    async void clicked2(object sender, EventArgs e)
    {
        await viewModel.addOutfit();

    }
    string GenerateRequestURL(string endPoint)
    {
        string requestUri = endPoint;
        requestUri += $"?q={_cityEntry.Text}";
        requestUri += "&units=imperial";
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
        return requestUri;
    }
}