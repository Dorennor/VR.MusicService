namespace VR.MusicService.Tool.Interface
{
    public interface ISettingsManager
    {
        bool IsFirstStartup { get; set; }

        void LoadSettings();

        Task LoadSettingsAsync();

        void SynchronizeSettings();

        Task SynchronizeSettingsAsync();

        void SaveSettings();

        Task SaveSettingsAsync();
    }
}