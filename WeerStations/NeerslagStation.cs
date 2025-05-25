using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Enum;

namespace WeerEventsApi.WeerStations;

public class NeerslagStation : WeerStation
{
    private static readonly Random rn = new();

    public NeerslagStation(Stad stad) : base(stad, "Neerslag") { }

    public override void DoeMeting()
    {
        double waarde = rn.NextDouble() * 50;
        var meting = new Meting(DateTime.Now, Math.Round(waarde, 1), MetingEenheid.MillimeterPerUur , Stad);
        RegistreerMeting(meting);
    }
}