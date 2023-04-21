using Mopups.Services;

namespace Dressing_Room;

public partial class RemoveBugPopup
{
    public RemoveBugPopup()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Task.Delay(50).Wait();
        MopupService.Instance.PopAllAsync();
    }

}