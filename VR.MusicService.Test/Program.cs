//using System.Security.Permissions;
//using Microsoft.Extensions.Configuration;

//namespace VR.MusicService.Test;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Settings settings = new Settings();

//        //string json = JsonConvert.SerializeObject(test.Settings, Formatting.Indented);
//        //File.WriteAllText("appsettings.json", json);

//        //Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("appsettings.json"));

//        //Console.WriteLine(bool.Parse(result["IsWork"]).GetType());

//        //settings.Test = true;
//        //Console.WriteLine(settings.Test);

//        Console.ReadKey();
//    }
//}

//public class Settings
//{
//    private IConfiguration Configuration;

//    //private bool _test;

//    //public bool Test
//    //{
//    //    get
//    //    {
//    //        _test = bool.Parse(Configuration["Test"]);
//    //        return _test;
//    //    }
//    //    set
//    //    {
//    //        _test = value;
//    //        Configuration["Test"] = _test.ToString();
//    //    }
//    //}

//    public Settings()
//    {
//        var builder = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//        Configuration = builder.Build();
//    }

//    private readonly IAudioManager _audioManager;
//    private IAudioPlayer _audioPlayer;
//    private FileResult _fileResult;
//    private double _pausePosition = default;

//    //private static readonly string Path = @"/storage/01D0-9200/Музыка";

//    //public List<Item> FilesNames { get; set; } = new List<Item>();

//    public MainPage(IAudioManager audioManager)
//    {
//        InitializeComponent();
//        _audioManager = audioManager;

//        if (Permissions.CheckStatusAsync<ReadWriteStoragePerms>().Result != PermissionStatus.Granted)
//            Permissions.RequestAsync<ReadWriteStoragePerms>();

//        //DirectoryInfo directoryInfo = new DirectoryInfo(Path);

//        //FileNameLabel.Text = $"{directoryInfo.GetFiles().First().Name}";

//        //var files = Directory.GetFiles(Path);

//        //FilesNames.Sort();

//        //foreach (var item in files)
//        //{
//        //    var name = item.Split('/');

//        //    FilesNames.Add(new Item
//        //    {
//        //        Title = name.Last(),
//        //        ButtonName = "Play"
//        //    });
//        //}

//        //MusicListView.ItemsSource = FilesNames;
//    }

//    private async void OpenFileButton_OnClicked(object sender, EventArgs e)
//    {
//        PickOptions options = new()
//        {
//            PickerTitle = "Please select a file",
//            FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
//                {
//                    { DevicePlatform.Android, new[] { "audio/mpeg" } }
//                })
//        };

//        _fileResult = await FilePicker.Default.PickAsync(options);
//    }

//    private async void PlayButton_OnClicked(object sender, EventArgs e)
//    {
//        if (_fileResult == null)
//            return;

//        FileNameLabel.Text = $"{_fileResult.FileName}";

//        await using var stream = await _fileResult.OpenReadAsync();

//        _audioPlayer = _audioManager.CreatePlayer(stream);
//        _audioPlayer.Seek(_pausePosition);
//        _audioPlayer.Play();
//    }

//    private void PauseButton_OnClicked(object sender, EventArgs e)
//    {
//        _pausePosition = _audioPlayer.CurrentPosition;
//        _audioPlayer.Pause();
//    }

//    private void StopButton_OnClicked(object sender, EventArgs e)
//    {
//        _audioPlayer.Stop();
//        _pausePosition = 0;
//    }

//    //private async void PlaySongButton_OnClicked(object sender, EventArgs e)
//    //{
//    //    var song = MusicListView.SelectedItem;

//    //    //if (_fileResult == null)
//    //    //    return;

//    //    //FileNameLabel.Text = $"{_fileResult.FileName}";

//    //    //await using var stream = await _fileResult.OpenReadAsync();

//    //    //_audioPlayer = _audioManager.CreatePlayer(stream);
//    //    //_audioPlayer.Seek(_pausePosition);
//    //    //_audioPlayer.Play();
//    //}
//}

//public class ReadWriteStoragePermissions : Permissions.BasePlatformPermission
//{
//    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
//        new List<(string androidPermission, bool isRuntime)>
//        {
//            (global::Android.Manifest.Permission.ReadExternalStorage, true),
//            (global::Android.Manifest.Permission.WriteExternalStorage, true)
//        }.ToArray();
//}

////public class Item
////{
////    public string Title { get; set; }
////    public string ButtonName { get; set; }
////}
/// //builder.Services.AddSingleton(AudioManager.Current);