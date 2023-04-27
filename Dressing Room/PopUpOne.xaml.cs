using CommunityToolkit.Maui.Views;
using Dressing_Room.ViewModels;
using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpOne
{
    public PopUpOne()
    {
        InitializeComponent();
    }
    private async void AddItemsToClosetButton(object sender, EventArgs e)
    {


        await MopupService.Instance.PushAsync(new PopUpTwo());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(CreateOutfit), typeof(CreateOutfit));
        await MopupService.Instance.PopAllAsync();
        await Shell.Current.GoToAsync(nameof(CreateOutfit));

    }

    private async void GoToGenerateOutfit(object sender, EventArgs e)
    {
        Routing.RegisterRoute(nameof(GenerateChoice), typeof(GenerateChoice));
        await Shell.Current.GoToAsync(nameof(GenerateChoice));
        await MopupService.Instance.PopAllAsync();

    }
}