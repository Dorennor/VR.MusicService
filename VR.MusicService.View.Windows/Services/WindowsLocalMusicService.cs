using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;

using VR.MusicService.Model.Interfaces;
using VR.MusicService.Model.Models;
using VR.MusicService.ViewModel.Interfaces;

namespace VR.MusicService.View.Windows.Services;

public class LocalMusicService : IMusicService
{
    private static readonly Random Randomizer;
    private static readonly MediaPlayer MediaPlayer;

    static LocalMusicService()
    {
        Randomizer = new Random();
        MediaPlayer = new MediaPlayer();
    }

    public ISong CurrentSong { get; private set; }

    public ISong Play()
    {
        MediaPlayer.Open(new Uri(CurrentSong.Path));
        MediaPlayer.Play();

        return CurrentSong;
    }

    public ISong Play(ISong song)
    {
        MediaPlayer.Open(new Uri(song.Path));
        MediaPlayer.Play();

        CurrentSong = song;

        return CurrentSong;
    }

    public ISong Pause(out int time)
    {
        throw new NotImplementedException();
    }

    public ISong Resume(int time)
    {
        throw new NotImplementedException();
    }

    public ISong? Stop()
    {
        MediaPlayer.Stop();

        return null;
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