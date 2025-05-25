using WeerEventsApi.Facade.Dto;
using WeerEventsApi.WeerStations;
using WeerEventsApi.WeerStations.Enum;

namespace WeerEventsApi.WeerBerichten;
public class Weermodel
{
     public string BepaalWeer(List<Meting> metingen)
     {
          if (metingen == null || metingen.Count == 0)
          { 
               return "onbekend weer";
          }
               

          double temperatuurGemiddelde = metingen
               .Where(m => m.Eenheid == MetingEenheid.GradenCelsius)
               .Select(m => m.Waarde)
               .DefaultIfEmpty(0)
               .Average();

          double windGemiddelde = metingen
               .Where(m => m.Eenheid == MetingEenheid.KilometerPerUur)
               .Select(m => m.Waarde)
               .DefaultIfEmpty(0)
               .Average();

          double neerslagGemiddelde = metingen
               .Where(m => m.Eenheid == MetingEenheid.MillimeterPerUur)
               .Select(m => m.Waarde)
               .DefaultIfEmpty(0)
               .Average();

          double luchtdrukGemiddelde = metingen
               .Where(m => m.Eenheid == MetingEenheid.HectoPascal)
               .Select(m => m.Waarde)
               .DefaultIfEmpty(0)
               .Average();

          bool goedWeer = temperatuurGemiddelde > 15 && windGemiddelde < 30 && neerslagGemiddelde < 5 && luchtdrukGemiddelde > 1000;
          
          return goedWeer ? "goed weer" : "slecht weer";
     }
}