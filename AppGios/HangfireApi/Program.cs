
using ApplicationGios.Options;
using InfrastructureGios;
using Shareed.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseConfigSeriLog(builder.Configuration, builder.Environment.EnvironmentName);

// change to autofac
var services = builder.Services;

services.Configure<GiosOptions>(builder.Configuration.GetSection("Gios"));
services.Configure<RedisOptions>(builder.Configuration.GetSection("Redis"));
services.Configure<KafkaOpions>(builder.Configuration.GetSection("Kafka"));

services.AddEndpointsApiExplorer(); 
services.AddInfrastructureServices(builder.Configuration);
services.AddDaprClient();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseInfrastructure();
app.UseRouting();

app.UseCloudEvents();
app.UseEndpoints(e =>
{
    e.MapSubscribeHandler();
});

app.MapGet("/", (HttpContext context) 
    => $" Hangfire - https://{context.Response.HttpContext.Request.Host.Host}:{context.Response.HttpContext.Request.Host.Port}/Hangfire");
app.Run();