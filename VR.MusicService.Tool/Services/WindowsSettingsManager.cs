using Microsoft.Extensions.Configuration;
using VR.MusicService.Tool.Interface;

namespace VR.MusicService.Tool.Services;

public class WindowsSettingsManager : ISettingsManager
{
    private readonly IConfiguration Configuration;

    public WindowsSettingsManager()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();
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