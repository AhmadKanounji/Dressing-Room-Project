namespace Dressing_Room;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Signup), typeof(Signup));

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

		Routing.RegisterRoute(nameof(WardrobePage), typeof(WardrobePage));
    }

    
}
