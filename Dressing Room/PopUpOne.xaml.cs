using CommunityToolkit.Maui.Views;
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
}