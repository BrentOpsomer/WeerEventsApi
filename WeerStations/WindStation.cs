using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Enum;

namespace WeerEventsApi.WeerStations;

public class WindStation : WeerStation
{
    private static readonly Random rn = new();

    public WindStation(Stad stad) : base(stad, "windstation") {}

    public override void DoeMeting()
    {
        double waarde = rn.NextDouble() * 100;
        var meting = new Meting(DateTime.Now, Math.Round(waarde, 1), MetingEenheid.KilometerPerUur, Stad);
        RegistreerMeting(meting);
    }
}