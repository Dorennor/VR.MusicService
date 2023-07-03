using CommunityToolkit.Maui;

using VR.MusicService.Tool.Interface;
using VR.MusicService.Tool.Services;
using VR.MusicService.View.Android.Service;
using VR.MusicService.ViewModel.Interfaces;
using VR.MusicService.ViewModel.ViewModels;

namespace VR.MusicService.View.Android;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder.Services.AddTransient<ISettingsManager, AndroidSettingsManager>();
        builder.Services.AddTransient<IDialogService, AndroidDialogService>();
        builder.Services.AddTransient<IMusicService, LocalMusicService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>(services => new MainPage
        {
            BindingContext = services.GetService<MainViewModel>()
        });

        return builder.Build();
    }
}