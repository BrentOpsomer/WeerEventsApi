namespace WeerEventsApi.WeerStations;

public interface IWeerstationManager
{
    IReadOnlyList<WeerStation> GeefWeerStations();
}