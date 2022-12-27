
using ApplicationGios;
using ApplicationGios.Options;
using InfrastructureGios;
using Shareed.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseConfigSeriLog(builder.Configuration, builder.Environment.EnvironmentName);

// todo change to autofac
var services = builder.Services;

services.Configure<GiosOptions>(builder.Configuration.GetSection("Gios"));
services.Configure<DaprOptions>(builder.Configuration.GetSection("Dapr"));
services.Configure<KafkaOpions>(builder.Configuration.GetSection("Kafka"));

services.ApplicationGiosServices();
services.AddEndpointsApiExplorer(); 
services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseInfrastructure();
app.UseRouting();


app.UseEndpoints(e =>
{
    e.MapSubscribeHandler();
});

app.MapGet(
    "/", 
    (HttpContext context) 
        => $" Hangfire - https://{context.Response.HttpContext.Request.Host.Host}:{context.Response.HttpContext.Request.Host.Port}/Hangfire");
app.Run();