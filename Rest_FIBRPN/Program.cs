var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
var app = builder.Build();
app.MapControllers();
app.Run();

//var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter; // FIXME: Hogyan kapcsoljuk be a szerializ�l�st
//json.UseDataContractJsonSerializer = true;
