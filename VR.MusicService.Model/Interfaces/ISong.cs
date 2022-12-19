namespace VR.MusicService.Model.Interfaces;

public interface ISong
{
    string Path { get; set; }
    string FileName { get; set; }
    string Name { get; set; }
}