using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;

namespace VR.MusicService.View.Windows;

public partial class MainWindow : Window
{
    private MediaPlayer mediaPlayer = new MediaPlayer();

    public MainWindow()
    {
        InitializeComponent();

        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            mediaPlayer.Open(new Uri(openFileDialog.FileName));
        }

        DispatcherTimer timer = new DispatcherTimer();

        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += timer_Tick;
        timer.Start();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        if (mediaPlayer.Source != null)
        {
            lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        }
        else
        {
            lblStatus.Content = "No file selected...";
        }
    }

    private void btnPlay_Click(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Play();
    }

    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Pause();
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Stop();
    }
}