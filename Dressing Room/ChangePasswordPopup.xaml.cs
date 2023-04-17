using Dressing_Room.ViewModels;

namespace Dressing_Room;

public partial class ChangePasswordPopup
{
    public ChangePasswordPopup(SettingsViewModel svm)
    {
        InitializeComponent();
        this.BindingContext = svm;
    }

}