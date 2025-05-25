using WeerEventsApi.ObserverInfrastructure;
namespace WeerEventsApi.WeerBerichten;

public interface IWeerberichtManager
{
    Weerbericht GeefWeerbericht();

    IMetingObserver Observer();
}