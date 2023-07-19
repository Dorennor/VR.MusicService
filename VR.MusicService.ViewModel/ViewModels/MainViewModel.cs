using System.Reflection;

using CommunityToolkit.Mvvm.Input;

using VR.MusicService.Model.Interfaces;
using VR.MusicService.Model.Models;
using VR.MusicService.ViewModel.Abstractions;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.ViewModel.ViewModels;

public class MainViewModel : BasicViewModel
{
    private List<ISong> _localSongs = new List<ISong>();

    private readonly IMusicService _musicService;
    private readonly IDialogService _dialogService;

    private ISong _currentSong;
    private ISong _selectedSong;

    public ISong SelectedSong
    {
        get => _selectedSong;
        set
        {
            if (value == _selectedSong)
                return;

            _selectedSong = value;
            OnPropertyChanged();
        }
    }

    private RelayCommand? _playCommand;
    private RelayCommand? _pauseCommand;
    private RelayCommand? _stopCommand;
    private RelayCommand? _openFileCommand;

    public MainViewModel(IMusicService musicService, IDialogService dialogService)
    {
        _musicService = musicService;
        _dialogService = dialogService;

        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Samples";

        var songs = Directory.GetFiles(path);

        foreach (var song in songs)
        {
            var splitedSongStrings = song.Split('\\');

            var fileName = splitedSongStrings.Last();

            var name = fileName.Substring(0, fileName.Length - 4);

            _localSongs.Add(new LocalSong
            {
                Path = song,
                FileName = fileName,
                Name = name
            });
        }

        OnPropertyChanged(nameof(LocalSongs));
    }

    public RelayCommand PlayCommand
    {
        get => _playCommand ?? new RelayCommand(() =>
        {
            if (CurrentSong == null)
                CurrentSong = SelectedSong;

            if (CurrentSong != null)
                CurrentSong = _musicService.Play(SelectedSong);
        });
    }

    public RelayCommand? PauseCommand
    {
        get => _pauseCommand ?? new RelayCommand(() =>
        {
        });
    }

    public RelayCommand? StopCommand
    {
        get => _stopCommand ?? new RelayCommand(() =>
        {
            CurrentSong = _musicService.Stop();
        });
    }

    public RelayCommand? OpenFileCommand
    {
        get => _openFileCommand ?? new RelayCommand(() =>
        {
            CurrentSong = _dialogService.OpenFileDialog();
        });
    }

    public ISong CurrentSong
    {
        get => _currentSong;
        set
        {
            if (value == _currentSong)
                return;

            _currentSong = value;
            OnPropertyChanged();
        }
    }

    public List<ISong> LocalSongs
    {
        get => _localSongs;
        set
        {
            if (value == _localSongs)
                return;

            _localSongs = value;
            OnPropertyChanged();
        }
    }
}