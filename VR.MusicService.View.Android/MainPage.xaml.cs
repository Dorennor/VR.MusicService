using VR.MusicService.View.Android.Helpers;

namespace VR.MusicService.View.Android;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        var task = Task.Run(() =>
        {
            if (Permissions.CheckStatusAsync<ReadWriteStoragePermissions>().Result != PermissionStatus.Granted)
                Permissions.RequestAsync<ReadWriteStoragePermissions>();
        });

        var awaiter = task.GetAwaiter();
        awaiter.OnCompleted(InitializeComponent);
    }
}