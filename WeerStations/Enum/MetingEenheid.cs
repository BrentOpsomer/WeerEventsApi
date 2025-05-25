using System.ComponentModel;

namespace WeerEventsApi.WeerStations.Enum;

public enum MetingEenheid
{
    [Description("kmh")]
    KilometerPerUur,
    
    [Description("mmh")]
    MillimeterPerUur,
    
    [Description("°C")]
    GradenCelsius,
    
    [Description("hPa")]
    HectoPascal
}