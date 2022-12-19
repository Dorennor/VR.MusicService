﻿using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VR.MusicService.View.Windows.Services;
using VR.MusicService.ViewModel.Interfaces;
using VR.MusicService.ViewModel.ViewModels;

namespace VR.MusicService.View.Windows;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices).Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IDialogService, WindowsDialogService>();
        services.AddTransient<IMusicService, LocalMusicService>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>(serviceCollection => new MainWindow
        {
            DataContext = serviceCollection.GetService<MainViewModel>()
        });
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }

        base.OnExit(e);
    }
}