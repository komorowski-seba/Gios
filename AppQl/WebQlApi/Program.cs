using Application;
using Application.Options;
using ApplicationGios.Options;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// builder.Host.UseConfigSeriLog(builder.Configuration, builder.Environment.EnvironmentName);

var services = builder.Services;

services.Configure<MartenOptions>(builder.Configuration.GetSection("Marten"));
services.Configure<DaprOptions>(builder.Configuration.GetSection("Dapr"));
services.Configure<ElasticOptions>(builder.Configuration.GetSection("Elastic"));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddApplicationServices();
// services.AddSwaggerGen();
// services.AddWebQlInfrastructureServices(builder.Configuration);

var app = builder.Build();
// if (app.Environment.IsDevelopment())
// {
//     // app.UseSwagger();
//     // app.UseSwaggerUI();
// }
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// app.UseQlConfiguration(app.Environment.IsDevelopment());
app.Run();