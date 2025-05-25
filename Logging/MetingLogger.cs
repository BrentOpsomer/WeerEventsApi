using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger
{
    public void Log(Meting meting)
    {
        Console.WriteLine(meting);
    }
}