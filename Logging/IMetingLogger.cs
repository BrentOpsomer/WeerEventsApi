using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging;

public interface IMetingLogger
{
    void Log(Meting meting);
}