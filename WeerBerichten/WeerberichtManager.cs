using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations;
using WeerEventsApi.ObserverInfrastructure;
namespace WeerEventsApi.WeerBerichten;

public class WeerberichtManager : IMetingObserver, IWeerberichtManager
{
    private readonly Random rn = new Random();
    private readonly List<Meting> _metingen;
    
    public WeerberichtManager()
    {
        _metingen = new List<Meting>();
    }

    public Weerbericht GeefWeerbericht()
    {
        Thread.Sleep(5000);

        var weermodel = new Weermodel();
        var weer = weermodel.BepaalWeer(_metingen);

        return new Weerbericht(DateTime.Now, 
            $"Op basis van {_metingen.Count} metingen en mijn diepzinnig computermodel kan ik zeggen dat het {weer} weer zal worden.");
    }

    public IMetingObserver Observer()
    {
        return this;
    }
    
    public void update(Meting meting)
    {
        _metingen.Add(meting);
    }
}