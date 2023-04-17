using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Mopups.Services;

namespace Dressing_Room;

public partial class LogoutPopup
{
    public LogoutPopup()
    {
        InitializeComponent();
    }
    private void OnButtonClicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAllAsync();

    }
    private async void OnButton2Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PopAllAsync();
        await Shell.Current.GoToAsync("//MainPage");
    }

}