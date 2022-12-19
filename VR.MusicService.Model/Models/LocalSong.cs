using VR.MusicService.Model.Interfaces;

namespace VR.MusicService.Model.Models;

public class LocalSong : ISong
{
    public string Path { get; set; }
    public string FileName { get; set; }
    public string Name { get; set; }
}