using CommunityToolkit.Mvvm.ComponentModel;

using VR.MusicService.Tool.Interface;

namespace VR.MusicService.Tool.Services;

public class AndroidSettingsManager : ObservableObject, ISettingsManager
{
    public bool IsFirstStartup { get; set; }

    public void SaveSettings()
    {
        throw new NotImplementedException();
    }

    public Task SaveSettingsAsync()
    {
        throw new NotImplementedException();
    }

    public void LoadSettings()
    {
        throw new NotImplementedException();
    }

    public Task LoadSettingsAsync()
    {
        throw new NotImplementedException();
    }

    public void SynchronizeSettings()
    {
        throw new NotImplementedException();
    }

    public Task SynchronizeSettingsAsync()
    {
        throw new NotImplementedException();
    }

    public string GetSettingByName(string name)
    {
        throw new NotImplementedException();
    }

    public void SetSettingByName(string name, string value)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, string> GetAllSettings()
    {
        throw new NotImplementedException();
    }
}