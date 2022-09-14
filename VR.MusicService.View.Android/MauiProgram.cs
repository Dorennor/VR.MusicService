using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace VR.MusicService.View.Android;

public static class MauiProgram
{
    private static IConfiguration Configuration { get; set; }

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

        var a = Assembly.GetExecutingAssembly();

        using var stream = a.GetManifestResourceStream("VR.MusicService.View.Android.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Configuration.AddConfiguration(config);

        return builder.Build();
    }
}