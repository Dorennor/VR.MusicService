using System.Linq;
using System.Windows;
using Microsoft.Win32;
using VR.MusicService.Model.Interfaces;
using VR.MusicService.Model.Models;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.View.Windows.Services;

internal class WindowsDialogService : IDialogService
{
    public bool ShowDialog(string message, string title)
    {
        MessageBox.Show(message, title);

        return true;
    }

    public ISong OpenFileDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        if (openFileDialog.ShowDialog() == true)
        {
            var path = openFileDialog.FileName;
            var fileName = path.Split('\\').Last();
            var name = fileName.Remove(fileName.Length - 4, 4);

            ISong song = new LocalSong
            {
                Path = path,
                FileName = fileName,
                Name = name
            };

            return song;
        }

        return null;
    }

    public IFolder OpenFolderDialog()
    {
        throw new System.NotImplementedException();
    }
}