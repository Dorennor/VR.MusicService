using CommunityToolkit.Mvvm.Input;
using VR.MusicService.ViewModel.Abstractions;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.ViewModel.ViewModels;

public class MainViewModel : BasicViewModel
{
    private readonly IMusicService _musicService;

    public MainViewModel(IMusicService musicService)
    {
        _musicService = musicService;
    }

    private RelayCommand? _playCommand;

    public RelayCommand PlayCommand
    {
        get => _playCommand ?? new RelayCommand(() =>
        {
            //var song = _musicService.GetRandomSong();

            //_musicService.Play(song);

            //string path = @"/storage/";

            //DirectoryInfo directoryInfo = new DirectoryInfo(path);

            //string result = "";
            
            //foreach (var item in directoryInfo.EnumerateDirectories())
            //{
            //    result += (item.Name + "\n");
            //}
            //var temp = AndroidX
            //FileName = ;
        });
    }

    private string _fileName;

    public string FileName
    {
        get => _fileName;
        set
        {
            if (string.IsNullOrEmpty(value) || value == _fileName)
                return;

            _fileName = value;
            OnPropertyChanged();
        }
    }
}