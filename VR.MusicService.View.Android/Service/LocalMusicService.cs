using VR.MusicService.Model.Interfaces;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.View.Android.Service;

public class LocalMusicService : IMusicService
{
    public ISong CurrentSong => throw new NotImplementedException();

    public List<ISong> GetAll()
    {
        throw new NotImplementedException();
    }

    public ISong GetRandomSong()
    {
        throw new NotImplementedException();
    }

    public List<ISong> GetRecommendedListSongs()
    {
        throw new NotImplementedException();
    }

    public ISong GetSong(Func<ISong, bool> finder)
    {
        throw new NotImplementedException();
    }

    public ISong Pause(out int time)
    {
        throw new NotImplementedException();
    }

    public ISong Play()
    {
        throw new NotImplementedException();
    }

    public ISong Play(ISong song)
    {
        throw new NotImplementedException();
    }

    public ISong Resume(int time)
    {
        throw new NotImplementedException();
    }

    public ISong Stop()
    {
        throw new NotImplementedException();
    }
}