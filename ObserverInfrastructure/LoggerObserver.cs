using WeerEventsApi.Logging;
using WeerEventsApi.WeerStations;

namespace WeerEventsApi.ObserverInfrastructure;

public class LoggerObserver : IMetingObserver
{
    private readonly IMetingLogger _logger;
    
    public LoggerObserver(IMetingLogger logger)
    {
        _logger = logger;
    }
    public void update(Meting meting)
    {
        _logger.Log(meting);
    }
}