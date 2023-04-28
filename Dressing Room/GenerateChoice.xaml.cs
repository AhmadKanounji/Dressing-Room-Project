namespace Dressing_Room;

public partial class GenerateChoice : ContentPage
{
    public GenerateChoice()
    {
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(GeneratePage), typeof(GeneratePage));
        await Shell.Current.GoToAsync(nameof(GeneratePage));
    }
    
}