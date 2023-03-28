using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpPlus
{
    
    public PopUpPlus()
	{
		InitializeComponent();
    }
    private async void OnImageClicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUpAdd());
    }
}