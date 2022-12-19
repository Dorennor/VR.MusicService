using CommunityToolkit.Mvvm.Input;
using VR.MusicService.Model.Interfaces;
using VR.MusicService.ViewModel.Abstractions;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.ViewModel.ViewModels;

public class MainViewModel : BasicViewModel
{
    private readonly IMusicService _musicService;
    private readonly IDialogService _dialogService;

    private ISong _currentSong;

    private RelayCommand? _playCommand;
    private RelayCommand? _pauseCommand;
    private RelayCommand? _stopCommand;
    private RelayCommand? _openFileCommand;

    public MainViewModel(IMusicService musicService, IDialogService dialogService)
    {
        _musicService = musicService;
        _dialogService = dialogService;
    }

    public RelayCommand PlayCommand
    {
        get => _playCommand ?? new RelayCommand(() =>
        {
            if (CurrentSong != null)
                CurrentSong = _musicService.Play(CurrentSong);
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
}