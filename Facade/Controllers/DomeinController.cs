using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Logging;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.WeerBerichten;
using WeerEventsApi.WeerStations;
using WeerEventsApi.WeerStations.Factories;
using WeerEventsApi.WeerStations.Enum;
namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerberichtManager _weerberichtManager;
    private readonly IWeerstationManager _weerstationManager;

    public DomeinController(IStadManager stadManager, IWeerberichtManager weerberichtManager, IWeerstationManager weerstationManager)
    {
        _stadManager = stadManager;
        _weerberichtManager = weerberichtManager;
        _weerstationManager = weerstationManager;
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations()
    {
        var weerstations = _weerstationManager.GeefWeerStations();
        return weerstations.Select(station => new WeerStationDto
        {
            Type = station.TypeStation,
            StadNaam = station.Stad.Naam,
            AantalMetingen = station.GetMetings().Count
        });
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        var weerstations = _weerstationManager.GeefWeerStations();

        var metingen = weerstations
            .SelectMany(station => station.GetMetings())
            .Select(meting => new MetingDto
            {
                Moment = meting.Moment,
                Waarde = meting.Waarde,
                Eenheid = meting.Eenheid switch
                {
                    MetingEenheid.KilometerPerUur => "kmh",
                    MetingEenheid.MillimeterPerUur => "mmh",
                    MetingEenheid.GradenCelsius => "°C",
                    MetingEenheid.HectoPascal => "hPa",
                    _ => meting.Eenheid.ToString()
                },
                StadNaam = meting.Locatie.Naam
            });

        return metingen;
    }

    public void DoeMetingen()
    {
        var weerstations = _weerstationManager.GeefWeerStations();
        foreach (var station in weerstations)
        {
           
            station.DoeMeting();
        }
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        var weerbericht = _weerberichtManager.GeefWeerbericht();
        return new WeerBerichtDto
        {
            MomentCreatie = weerbericht.Moment,
            Inhoud = weerbericht.Inhoud
        };
    }
}