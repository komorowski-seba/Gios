using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Shareed.Extensions;

public static class SeriLogExtension
{
    public static IHostBuilder UseConfigSeriLog(
        this IHostBuilder builder, 
        IConfiguration config, 
        string environmentName)
    {
        builder.UseSerilog();
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .Enrich.FromLogContext()  
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config["Elasticsearch:Url"]))  
            {  
                AutoRegisterTemplate = true,  
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy-MM}"  
            })  
            .Enrich.WithProperty("Environment", environmentName)  
            .ReadFrom.Configuration(config)  
            .CreateLogger();  
        return builder;
    }

}