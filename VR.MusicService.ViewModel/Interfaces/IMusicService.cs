using VR.MusicService.Model.Interfaces;

namespace VR.MusicService.ViewModel.Interfaces;

public interface IMusicService
{
    ISong Play();

    ISong Play(ISong song);

    ISong Pause(out int time);

    ISong Resume(int time);

    ISong Stop();

    ISong GetSong(Func<ISong, bool> finder);

    ISong GetRandomSong();

    List<ISong> GetAll();

    List<ISong> GetRecommendedListSongs();

    ISong CurrentSong { get; }
}