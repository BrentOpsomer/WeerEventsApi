namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson = false, bool decorateWithXml = false)
    {
        IMetingLogger logger = new MetingLogger();
            
        if (decorateWithJson)
            logger = new JsonLogger(logger);
                
        if (decorateWithXml)
            logger = new XmlLogger(logger);
                
        return logger;
    }
}