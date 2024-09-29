using Microsoft.AspNetCore.SignalR;

namespace BookRateNetCore.Server.Hubs
{
    public class MqttHub : Hub
    {
        public async Task SendMessage(string topic, string payload)
        {
            await Clients.All.SendAsync("ReceiveMessage", topic, payload);
        }
    }
}
