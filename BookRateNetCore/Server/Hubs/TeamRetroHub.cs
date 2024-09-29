using Microsoft.AspNetCore.SignalR;
using BookRateNetCore.Shared;

namespace BookRateNetCore.Server.Hubs
{
    public class TeamRetroHub : Hub<ITeamRetroHub>
    {
        static int clientCount;   
        
        public async Task SendRetroItem(RetrospectiveItem item)
        {
            await Clients.All.ReceiveRetroItem(item);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.UpdateClientsCount(clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clientCount--;
            await Clients.All.UpdateClientsCount(clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
