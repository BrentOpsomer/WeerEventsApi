using WeerEventsApi.ObserverInfrastructure;

namespace WeerEventsApi.WeerBerichten;

public class WeerberichtProxy : IWeerberichtManager
{
    private readonly IWeerberichtManager _echteWeerberichtManager;
        
    private Weerbericht _cachedWeerbericht;
        
    private DateTime _laatsteToegangTijd;
    
    public WeerberichtProxy(IWeerberichtManager echteWeerberichtManager)
    {
        _echteWeerberichtManager = echteWeerberichtManager;
            
        _cachedWeerbericht = null;
            
        _laatsteToegangTijd = DateTime.MinValue;
    }
    
    public Weerbericht GeefWeerbericht()
    {
        if (_cachedWeerbericht == null || DateTime.Now.Subtract(_laatsteToegangTijd).TotalMinutes > 1)
        {
            Console.WriteLine("Het weerbericht wordt nu gegenereerd (lazy loading)...");

            _cachedWeerbericht = _echteWeerberichtManager.GeefWeerbericht();
                
            _laatsteToegangTijd = DateTime.Now;
        }
        else
        {
            Console.WriteLine("Het gecachete weerbericht wordt gebruikt.");
        }

        return _cachedWeerbericht;
    }

    public IMetingObserver Observer()
    {
        return _echteWeerberichtManager.Observer();
    }
}