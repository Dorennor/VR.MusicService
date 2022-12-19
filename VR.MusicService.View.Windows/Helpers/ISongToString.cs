using System;
using System.Globalization;
using System.Windows.Data;
using VR.MusicService.Model.Interfaces;

namespace VR.MusicService.View.Windows.Helpers;

public class ISongToString : IValueConverter
{
    public static IValueConverter Converter { get; } = new ISongToString();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is not ISong song ? "Empty" : song.Name;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return new NotImplementedException();
    }
}