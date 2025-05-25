using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Enum;

namespace WeerEventsApi.WeerStations;

public class LuchtdrukStation : WeerStation
{
    private static readonly Random rn = new();

    public LuchtdrukStation(Stad stad) : base(stad, "luchtdruk") {}

    public override void DoeMeting()
    {
        double waarde = rn.NextDouble() * 100 + 950;
        var meting = new Meting(DateTime.Now, Math.Round(waarde, 1), MetingEenheid.HectoPascal, Stad);
        RegistreerMeting(meting);
    }
}