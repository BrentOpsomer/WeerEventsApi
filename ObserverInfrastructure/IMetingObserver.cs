using WeerEventsApi.WeerStations;

namespace WeerEventsApi.ObserverInfrastructure;

public interface IMetingObserver
{
    void update(Meting meting);
}