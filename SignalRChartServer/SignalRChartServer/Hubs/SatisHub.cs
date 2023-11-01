using Microsoft.AspNetCore.SignalR;

namespace SignalRChartServer.Hubs;

public class SatisHub : Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("receiveMessage", "merhaba");
    }
}