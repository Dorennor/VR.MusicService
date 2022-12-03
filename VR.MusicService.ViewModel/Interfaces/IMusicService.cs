using VR.MusicService.Model.Interfaces;

namespace VR.MusicService.ViewModel.Interfaces;

public interface IMusicService
{
    ISong Play(ISong song);

    ISong Pause(ISong song, out int time);

    ISong Resume(ISong song, int time);

    ISong Stop(ISong song);

    ISong GetSong(Func<ISong, bool> finder);

    ISong GetRandomSong();

    List<ISong> GetAll();

    List<ISong> GetRecommendedListSongs();

    ISong CurrentSong { get; }
}