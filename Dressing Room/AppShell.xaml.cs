using Dressing_Room.Wardrobe_Extensions;

namespace Dressing_Room;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Signup), typeof(Signup));


		

       




    }

    
}
