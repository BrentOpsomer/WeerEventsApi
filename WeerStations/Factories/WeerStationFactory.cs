using WeerEventsApi.Steden;
namespace WeerEventsApi.WeerStations.Factories;

public class WeerStationFactory
{
    private static readonly Random _random = new();

    public static List<WeerStation> MaakStations(List<Stad> steden)
    {
        var stations = new List<WeerStation>();
        var types = new List<Func<Stad, WeerStation>>
        {
            stad => new TemperatuurStation(stad),
            stad => new WindStation(stad),
            stad => new NeerslagStation(stad),
            stad => new LuchtdrukStation(stad)
        };

        for (int i = 0; i < 12; i++)
        {
            var stad = steden[_random.Next(steden.Count)];
            var maakStation = types[_random.Next(types.Count)];
            stations.Add(maakStation(stad));
        }

        return stations;
    }
}