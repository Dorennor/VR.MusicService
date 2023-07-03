using System.Windows;
using System.Windows.Input;

using VR.MusicService.Tool.Interface;
using VR.MusicService.Tool.Services;

namespace VR.MusicService.View.Windows;

public partial class MainWindow : Window
{
    private readonly ISettingsManager _settingsManager;

    public MainWindow()
    {
        _settingsManager = new WindowsSettingsManager();
    }

    private void ExitButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Minimize_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void PlayButton_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void PauseButton_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void StopButton_OnClick(object sender, RoutedEventArgs e)
    {
    }
}