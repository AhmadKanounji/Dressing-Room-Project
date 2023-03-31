using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Dressing_Room.Wardrobe_Extensions;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using CommunityToolkit.Maui;

namespace Dressing_Room;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureMopups()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("OPTIMA_B.TTF", "OPTIMA_B");
                fonts.AddFont("OPTIMA.TTF", "OPTIMA");
                fonts.AddFont("Quora.ttf", "Quora");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		//view

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<Signup>();
        builder.Services.AddSingleton<AccessoriesPage>();
        builder.Services.AddSingleton<JacketsPage>();
        builder.Services.AddSingleton<OutfitsPage>();
        builder.Services.AddSingleton<PantsPage>();
        builder.Services.AddSingleton<TopsPage>();
        builder.Services.AddSingleton<ShoesPage>();

        //viewmodel
        builder.Services.AddSingleton<SignupViewModel>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<ClothViewModel>();
       
        // services
        builder.Services.AddSingleton<SignUpService>();
		

		return builder.Build();
	}
}
