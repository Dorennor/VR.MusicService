using Plugin.Maui.Audio;

namespace VR.MusicService.View.Android;

public partial class MainPage : ContentPage
{
    private readonly IAudioManager _audioManager;
    private IAudioPlayer _audioPlayer;
    private FileResult fileResult;

    public MainPage(IAudioManager audioManager)
    {
        InitializeComponent();

        _audioManager = audioManager;
    }

    private async void OpenFileButton_OnClicked(object sender, EventArgs e)
    {
        PickOptions options = new()
        {
            PickerTitle = "Please select a file",
            FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "audio/mpeg" } }
                })
        };

        fileResult = await FilePicker.Default.PickAsync(options);
    }

    private async void PlayButton_OnClicked(object sender, EventArgs e)
    {
        if (fileResult != null)
        {
            FileNameLabel.Text = $"{fileResult.FileName}";

            await using var stream = await fileResult.OpenReadAsync();

            _audioPlayer = _audioManager.CreatePlayer(stream);
            _audioPlayer.Play();
        }
    }

    private void PauseButton_OnClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void StopButton_OnClicked(object sender, EventArgs e)
    {
        _audioPlayer.Stop();
    }
}