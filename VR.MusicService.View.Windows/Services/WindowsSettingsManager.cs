using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using Newtonsoft.Json;

using VR.MusicService.Tool.Interface;

namespace VR.MusicService.Tool.Services;

public class WindowsSettingsManager : ObservableObject, ISettingsManager
{
    private static readonly string SettingsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\settings.json";

    public WindowsSettingsManager()
    {
        if (File.Exists(SettingsPath))
        {
            LoadSettings();
        }
        else
        {
            SynchronizeSettings();
        }
    }

    public bool IsFirstStartup { get; set; } = true;

    public void SaveSettings()
    {
        JsonSerializer jsonSerializer = new JsonSerializer();

        using (StreamWriter stringWriter = new StreamWriter(SettingsPath))
        {
            using (JsonWriter jsonWriter = new JsonTextWriter(stringWriter))
            {
                jsonSerializer.Serialize(jsonWriter, this);
            }
        }
    }

    public async Task SaveSettingsAsync()
    {
        await Task.Run(SaveSettings);
    }

    public void SynchronizeSettings()
    {
        LoadSettings();
        SaveSettings();
    }

    public async Task SynchronizeSettingsAsync()
    {
        await LoadSettingsAsync();
        await SaveSettingsAsync();
    }

    public void LoadSettings()
    {
        using (StreamReader stringReader = new StreamReader(SettingsPath))
        {
            var json = stringReader.ReadToEnd();

            var deserializedProduct = JsonConvert.DeserializeObject<WindowsSettingsManager>(json);
        }
    }

    public Task LoadSettingsAsync()
    {
        throw new NotImplementedException();
    }
}