using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WeerEventsApi.WeerStations;
namespace WeerEventsApi.Logging;

public class XmlLogger : IMetingLogger
{
    
    private readonly IMetingLogger _innerLogger;
    private const string LogFile = "log.xml";
    private static readonly object _lock = new object();

    public XmlLogger(IMetingLogger innerLogger)
    {
        _innerLogger = innerLogger;
    }

    public void Log(Meting meting)
    {
        _innerLogger?.Log(meting);

        lock (_lock)
        {
            var serializer = new XmlSerializer(typeof(Meting));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                OmitXmlDeclaration = true
            };

            var xmlBuilder = new StringBuilder();
            using (var writer = XmlWriter.Create(xmlBuilder, settings))
            {
                serializer.Serialize(writer, meting);
            }

            File.AppendAllText(LogFile, xmlBuilder + Environment.NewLine);
        }
    }

}