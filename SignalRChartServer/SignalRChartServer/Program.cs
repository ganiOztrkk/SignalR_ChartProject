using SignalRChartServer.Hubs;
using SignalRChartServer.Models;
using SignalRChartServer.Subscription;
using SignalRChartServer.Subscription.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowCredentials();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.SetIsOriginAllowed(isOriginAllowed => true);
    });
});
builder.Services.AddSingleton<DatabaseSubscription<Satislar>>();
builder.Services.AddSingleton<DatabaseSubscription<Personeller>>();



var app = builder.Build();

app.UseDatabaseSubscription<DatabaseSubscription<Satislar>>("Satislar");
app.UseDatabaseSubscription<DatabaseSubscription<Personeller>>("Personeller");

app.UseCors();
app.UseRouting();
app.MapHub<SatisHub>("/satishub");

app.Run();