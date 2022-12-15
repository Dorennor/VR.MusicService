using VR.MusicService.View.Android.Helpers;
using Environment = Android.OS.Environment;
using File = Java.IO.File;

namespace VR.MusicService.View.Android;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        if (Permissions.CheckStatusAsync<ReadWriteStoragePermissions>().Result != PermissionStatus.Granted)
            Permissions.RequestAsync<ReadWriteStoragePermissions>();
    }

    private async void PlayButton_OnClicked(object sender, EventArgs e)
    {
        //string fileName = "/storage/emulated/0";

        try
        {
            //var variables = System.Environment.GetEnvironmentVariables();

            //DirectoryInfo directoryInfo = new DirectoryInfo(@"/mnt/sdcard/external_sd");
            //File.PathSeparator
            //string result = default;

            //foreach (var item in directoryInfo.EnumerateDirectories())
            //{
            //    result += (item + "\n");
            //}

            //FileNameLabel.Text = result;
            string storages = (string)System.Environment.GetEnvironmentVariables()["SECONDARY_STORAGE"];
            FileNameLabel.Text = storages;
        }
        catch
        {
            FileNameLabel.Text = "Error";
            await DisplayAlert("Title", "Message", "Cancel");
        }
    }

    private void PauseButton_OnClicked(object sender, EventArgs e)
    {
        //string fileName = "/storage/" + "01D0-9200";
    }
}