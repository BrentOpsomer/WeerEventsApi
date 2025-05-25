using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Enum;

namespace WeerEventsApi.WeerStations;

public class TemperatuurStation : WeerStation
{
    private static readonly Random rn = new();

    public TemperatuurStation(Stad stad) : base(stad, "temperatuur") {}

    public override void DoeMeting()
    {
        double waarde = rn.NextDouble() * 40 - 10;
        var meting = new Meting(DateTime.Now, Math.Round(waarde, 1), MetingEenheid.GradenCelsius, Stad);
        RegistreerMeting(meting);
        Console.WriteLine($"Meting toegevoegd bij {TypeStation} station in {Stad.Naam}. Totaal: {metingen.Count}");
    }
}