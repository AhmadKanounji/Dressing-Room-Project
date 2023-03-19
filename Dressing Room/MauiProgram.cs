﻿using Dressing_Room.ViewModels;
using Microsoft.Extensions.Logging;

namespace Dressing_Room;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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


		//viewmodel
		builder.Services.AddSingleton<SignupViewModel>();
		builder.Services.AddSingleton<MainPageViewModel>();
		

		return builder.Build();
	}
}
