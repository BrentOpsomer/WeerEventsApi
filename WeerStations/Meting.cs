using System.Xml.Serialization;
using WeerEventsApi.Steden;
using WeerEventsApi.WeerStations.Enum;

namespace WeerEventsApi.WeerStations;

public class Meting
{
    public DateTime Moment { get; set; }
    public double Waarde { get; set; }
    public MetingEenheid Eenheid { get; set; }
    
    // Optioneel: niet mee serializeren
    [XmlIgnore]
    public Stad Locatie { get; set; }

    public Meting() { }

    public Meting(DateTime moment, double waarde, MetingEenheid eenheid, Stad locatie)
    {
        Moment = moment;
        Waarde = waarde;    
        Eenheid = eenheid;
        Locatie = locatie;
    }
}