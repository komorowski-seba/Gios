using Application;
using Application.Options;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseConfigSeriLog(builder.Configuration, builder.Environment.EnvironmentName);

var services = builder.Services;

services.Configure<MartenOptions>(builder.Configuration.GetSection("Marten"));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddApplicationServices();
services.AddAppQLMediatorServices();
services.AddExternalEventsServices();
services.AddInternalEventsServices();
// services.AddSwaggerGen();
services.AddWebQlInfrastructureServices(builder.Configuration);

var app = builder.Build();
// if (app.Environment.IsDevelopment())
// {
//     // app.UseSwagger();
//     // app.UseSwaggerUI();
// }
app.UsePersistenceConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseQlConfiguration(app.Environment.IsDevelopment());
app.Run();