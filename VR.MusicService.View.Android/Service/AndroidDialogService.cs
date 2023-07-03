using VR.MusicService.Model.Interfaces;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.View.Android.Service;

public class AndroidDialogService : IDialogService
{
    public ISong OpenFileDialog()
    {
        throw new NotImplementedException();
    }

    public IFolder OpenFolderDialog()
    {
        throw new NotImplementedException();
    }

    public bool ShowDialog(string message, string title)
    {
        throw new NotImplementedException();
    }
}