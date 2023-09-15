using CommunityToolkit.Maui;
using MeusLivros.MVVM.ViewModels;
using MeusLivros.MVVM.Views;
using MeusLivros.Services;
using Microsoft.Extensions.Logging;

namespace MeusLivros;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
        // ViewModels
        builder.Services.AddSingleton<LivrosViewModel>();
        builder.Services.AddTransient<AddLivroViewModel>();
        builder.Services.AddTransient<UpdateLivroViewModel>();

        // Views
        builder.Services.AddSingleton<LivrosPage>();
        builder.Services.AddTransient<AddLivroPage>();
        builder.Services.AddTransient<UpdateLivroPage>();

        // Service
        builder.Services.AddSingleton<ILivroService, LivroService>();

        return builder.Build();
    }
}