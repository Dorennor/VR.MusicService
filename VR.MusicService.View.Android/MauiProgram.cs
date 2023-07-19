using VR.MusicService.ViewModel.Interfaces;
using VR.MusicService.ViewModel.ViewModels;

namespace VR.MusicService.View.Android;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>();

        builder.Services.AddSingleton<IMusicService, LocalMusicService>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainPage>(services => new MainPage
        {
            BindingContext = services.GetService<MainViewModel>()
        });

        return builder.Build();
    }
}