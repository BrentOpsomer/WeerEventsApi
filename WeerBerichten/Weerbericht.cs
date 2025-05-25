namespace WeerEventsApi.WeerBerichten;

public class Weerbericht
{
    public DateTime Moment { get; set; }
    public string Inhoud { get; set; }
    
    public Weerbericht(DateTime moment, string inhoud)
    {
        Moment = moment;
        Inhoud = inhoud;
    }
}