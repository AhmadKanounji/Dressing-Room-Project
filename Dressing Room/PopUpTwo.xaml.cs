using Dressing_Room.ViewModels;
using Mopups.Services;

namespace Dressing_Room;

public partial class PopUpTwo
{
    public PopUpTwo()
    {
        InitializeComponent();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new PopUpAdd());
    }
}