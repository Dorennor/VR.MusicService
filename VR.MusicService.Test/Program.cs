using Microsoft.Extensions.Configuration;

namespace VR.MusicService.Test;

public class Program
{
    public static void Main(string[] args)
    {
        Settings settings = new Settings();

        //string json = JsonConvert.SerializeObject(test.Settings, Formatting.Indented);
        //File.WriteAllText("appsettings.json", json);

        //Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("appsettings.json"));

        //Console.WriteLine(bool.Parse(result["IsWork"]).GetType());

        //settings.Test = true;
        //Console.WriteLine(settings.Test);

        Console.ReadKey();
    }
}

public class Settings
{
    private IConfiguration Configuration;

    //private bool _test;

    //public bool Test
    //{
    //    get
    //    {
    //        _test = bool.Parse(Configuration["Test"]);
    //        return _test;
    //    }
    //    set
    //    {
    //        _test = value;
    //        Configuration["Test"] = _test.ToString();
    //    }
    //}

    public Settings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        Configuration = builder.Build();
    }
}