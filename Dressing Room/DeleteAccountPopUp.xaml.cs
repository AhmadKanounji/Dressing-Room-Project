using Dressing_Room.ViewModels;
using Mopups.Services;

namespace Dressing_Room;

public partial class DeleteAccountPopUp
{
    public DeleteAccountPopUp(SettingsViewModel svm)
    {
        InitializeComponent();
        this.BindingContext = svm;
    }
    private void OnButtonClicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAllAsync();

    }
}