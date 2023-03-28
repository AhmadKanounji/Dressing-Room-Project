using Dressing_Room.Wardrobe_Extensions;

namespace Dressing_Room;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Signup), typeof(Signup));

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

		Routing.RegisterRoute(nameof(WardrobePage), typeof(WardrobePage));

        Routing.RegisterRoute(nameof(OutfitsPage), typeof(OutfitsPage));

        Routing.RegisterRoute(nameof(AccessoriesPage), typeof(AccessoriesPage));

        Routing.RegisterRoute(nameof(JacketsPage), typeof(JacketsPage));

        Routing.RegisterRoute(nameof(PantsPage), typeof(PantsPage));

        Routing.RegisterRoute(nameof(TopsPage), typeof(TopsPage));

        Routing.RegisterRoute(nameof(ShoesPage), typeof(ShoesPage));




    }

    
}
