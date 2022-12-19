using VR.MusicService.Model.Interfaces;

namespace VR.MusicService.ViewModel.Interfaces;

public interface IDialogService
{
    bool ShowDialog(string message, string title);

    ISong OpenFileDialog();

    IFolder OpenFolderDialog();
}