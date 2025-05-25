namespace WeerEventsApi.Facade.Dto;
public class WeerStationDto
{
    public required string Type { get; set; }
    public required string StadNaam { get; set; }
    public required int AantalMetingen  { get; set; }
}