using System.Text.Json;
using WeerEventsApi.WeerStations;

namespace WeerEventsApi.Logging;

public class JsonLogger : IMetingLogger
{
    private readonly IMetingLogger _innerLogger;
    private const string FilePath = "log.json";

    public JsonLogger(IMetingLogger innerLogger)
    {
        _innerLogger = innerLogger;
    }

    public void Log(Meting meting)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(meting, options);
        File.AppendAllText(FilePath, json + Environment.NewLine);
        
        _innerLogger?.Log(meting);
    }
}