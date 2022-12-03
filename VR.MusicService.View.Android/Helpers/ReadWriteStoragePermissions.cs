namespace VR.MusicService.View.Android.Helpers;

public class ReadWriteStoragePermissions : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
        new List<(string androidPermission, bool isRuntime)>
        {
            (global::Android.Manifest.Permission.ReadExternalStorage, true),
            (global::Android.Manifest.Permission.WriteExternalStorage, true)
        }.ToArray();
}