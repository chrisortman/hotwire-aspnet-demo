using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HotwireApplication.Hubs
{
    public class StreamsHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
    }
}