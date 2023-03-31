using CommunityToolkit.Maui.Views;

namespace Dressing_Room;

public partial class PopUpOne : Popup
{
	public PopUpOne()
	{
		InitializeComponent();
	}
    private void OKButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}