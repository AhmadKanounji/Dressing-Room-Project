using Dressing_Room.Services;
using Dressing_Room.ViewModels;
using Dressing_Room.Wardrobe_Extensions;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using CommunityToolkit.Maui;
using Microsoft.Maui.Handlers;

namespace Dressing_Room;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            //.useSkiaSharp()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OPTIMA_B.TTF", "OPTIMA_B");
                fonts.AddFont("OPTIMA.TTF", "OPTIMA");
                fonts.AddFont("Quora.ttf", "Quora");
                fonts.AddFont("NotoSansMyanmar-Medium.ttf", "NotoSansMyanmar");
                fonts.AddFont("Roboto-Medium.ttf", "Roboto");
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
        builder.Services.AddSingleton<TopsViewModel>();
        builder.Services.AddSingleton<ShoesViewModel>();
        builder.Services.AddSingleton<CreateOutfitViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<ProfileViewModel>();
        builder.Services.AddSingleton<PopupEditProfViewModel>();

        // services
        builder.Services.AddSingleton<SignUpService>();
        builder.Services.AddSingleton<ClothingService>();
        builder.Services.AddSingleton<EditProfileViewModel>();
        builder.Services.AddSingleton<OufitViewModel>();


        return builder.Build();
    }
}

