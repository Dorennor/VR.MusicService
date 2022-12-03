using VR.MusicService.Model.Interfaces;
using VR.MusicService.Model.Models;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.ViewModel.Services;

public class LocalMusicService : IMusicService
{
    private static readonly Random Random = new Random();

    public ISong CurrentSong { get; private set; }

    public ISong Play(ISong song)
    {
        throw new NotImplementedException();
    }

    public ISong Pause(ISong song, out int time)
    {
        throw new NotImplementedException();
    }

    public ISong Resume(ISong song, int time)
    {
        throw new NotImplementedException();
    }

    public ISong Stop(ISong song)
    {
        throw new NotImplementedException();
    }

    public ISong GetSong(Func<ISong, bool> finder)
    {
        throw new NotImplementedException();
    }

    public ISong GetRandomSong()
    {
        string path = @"/storage/01D0-9200/Музыка";

        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        var songs = directoryInfo.GetFiles();

        ISong song = new LocalSong
        {
            FileName = songs.First().Name
        };

        return song;
    }

    public List<ISong> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<ISong> GetRecommendedListSongs()
    {
        throw new NotImplementedException();
    }
}