namespace VR.MusicService.Tool.Interface
{
    public interface ISettingsManager
    {
        string GetSettingByName(string name);

        void SetSettingByName(string name, string value);

        Dictionary<string, string> GetAllSettings();
    }
}