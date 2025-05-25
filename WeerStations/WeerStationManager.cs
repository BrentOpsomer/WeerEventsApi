using WeerEventsApi.ObserverInfrastructure;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.WeerStations.Factories;

namespace WeerEventsApi.WeerStations;

public class WeerStationManager : IWeerstationManager
{
    private readonly List<WeerStation> _stations;

    public WeerStationManager(IStadManager stadManager, MetingNotifier notifier)
    {
        _stations = WeerStationFactory.MaakStations(stadManager.GeefSteden().ToList()).ToList();
        notifier.KoppelStations(_stations);
    }
    
    public IReadOnlyList<WeerStation> GeefWeerStations()
    {
        return _stations.AsReadOnly();
    }
}