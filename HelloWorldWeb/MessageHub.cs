using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace HelloWorldWeb
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class MessageHub: Hub
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public async Task SendMessage(string user, string message) => await this.Clients.All.SendAsync("ReceiveMessage", user, message);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}