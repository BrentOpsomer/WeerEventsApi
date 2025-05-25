using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.WeerBerichten;
using WeerEventsApi.ObserverInfrastructure;
using WeerEventsApi.WeerStations;

var builder = WebApplication.CreateBuilder(args);

//DI
builder.Services.AddSingleton<IMetingLogger>(_ => MetingLoggerFactory.Create(true, true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<WeerberichtManager>();
builder.Services.AddSingleton<MetingNotifier>(provider =>
{
    var notifier = new MetingNotifier();
    notifier.RegistreerObserver(new LoggerObserver(provider.GetRequiredService<IMetingLogger>()));
    notifier.RegistreerObserver(provider.GetRequiredService<WeerberichtManager>().Observer());
    return notifier;
});
builder.Services.AddSingleton<IWeerstationManager>(provider =>
    new WeerStationManager(provider.GetRequiredService<IStadManager>(), provider.GetRequiredService<MetingNotifier>()));
builder.Services.AddSingleton<IWeerberichtManager>(provider =>
    new WeerberichtProxy(provider.GetRequiredService<WeerberichtManager>()));
builder.Services.AddSingleton<IDomeinController>(provider =>
    new DomeinController(
        provider.GetRequiredService<IStadManager>(),
        provider.GetRequiredService<IWeerberichtManager>(),
        provider.GetRequiredService<IWeerstationManager>()
    ));

var app = builder.Build();

// Map routes
app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");
app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());
app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());
app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());
app.MapPost("/commands/meting-command", (IDomeinController dc) => { dc.DoeMetingen(); return Results.Ok(); });
app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());

app.Run();
