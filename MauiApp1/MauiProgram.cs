namespace MauiApp1;

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
            });

        builder.ConfigureSyncfusionCore();
        // services
        builder.Services.AddSingleton<MonkeyService>();
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);
        // view models
        builder.Services.AddTransient<MonkeysViewModel>();
        builder.Services.AddTransient<MonkeyDetailsViewModel>();
        // pages
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<DetailsPage>();
        return builder.Build();
    }
}
