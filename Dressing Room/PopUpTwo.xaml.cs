using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpTwo
{
	public PopUpTwo()
	{
		InitializeComponent();
	}
    private async void TakePhoto(object sender, EventArgs e)
    {

        await MopupService.Instance.PushAsync(new PopUpAdd());
    }
}