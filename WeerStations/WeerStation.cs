using WeerEventsApi.Steden;

namespace WeerEventsApi.WeerStations;

public abstract class WeerStation
{
    protected readonly List<Meting> metingen = new List<Meting>();
    public Stad Stad { get; set; }
    public string TypeStation { get; set; }
    public event Action<Meting>? MetingGedaan;
    
    protected WeerStation(Stad stad, string typeStation)
    {
        Stad = stad;
        TypeStation = typeStation;
    }

    public abstract void DoeMeting();

    public List<Meting> GetMetings()
    {
        return new List<Meting>(metingen);
    }
    
    protected void RegistreerMeting(Meting meting)
    {
        metingen.Add(meting);
        MetingGedaan?.Invoke(meting);
    }

}