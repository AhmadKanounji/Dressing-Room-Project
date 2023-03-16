namespace Dressing_Room;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new Microsoft.Maui.Controls.NavigationPage(new MainPage());
    }
}
