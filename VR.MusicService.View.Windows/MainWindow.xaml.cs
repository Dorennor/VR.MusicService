using System.Windows;
using System.Windows.Input;

namespace VR.MusicService.View.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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