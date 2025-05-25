using WeerEventsApi.WeerStations;
namespace WeerEventsApi.ObserverInfrastructure;

public class MetingNotifier
{
    private readonly List<IMetingObserver> observers = new();

    public void RegistreerObserver(IMetingObserver observer)
    {
        observers.Add(observer);
    }

    public void KoppelStations(List<WeerStation> stations)
    {
        foreach (var station in stations)
        {
            station.MetingGedaan += meting =>
            {
                foreach (var observer in observers)
                {
                    observer.update(meting);
                }
            };
        }
    } 
}