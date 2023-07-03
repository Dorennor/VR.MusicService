using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using VR.MusicService.Model.Interfaces;
using VR.MusicService.ViewModel.Abstractions;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.ViewModel.ViewModels;

public partial class MainViewModel : BasicViewModel
{
    private readonly IMusicService _musicService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private List<ISong> _localSongs;

    [ObservableProperty]
    private ISong _currentSong;

    [ObservableProperty]
    private ISong _selectedSong;

    public MainViewModel(IMusicService musicService, IDialogService dialogService)
    {
        _musicService = musicService;
        _dialogService = dialogService;
    }

    [RelayCommand]
    public void Play()
    {
        if (CurrentSong == null)
            CurrentSong = SelectedSong;

        if (CurrentSong != null)
            CurrentSong = _musicService.Play(SelectedSong);
    }

    [RelayCommand]
    public void Pause()
    {
    }

    [RelayCommand]
    public void Stop()
    {
        CurrentSong = _musicService.Stop();
    }

    [RelayCommand]
    public void OpenFile()
    {
        CurrentSong = _dialogService.OpenFileDialog();
    }
}