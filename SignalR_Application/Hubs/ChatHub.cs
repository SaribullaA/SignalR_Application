using Microsoft.AspNetCore.SignalR;

namespace SignalR_Application.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine($"User: {user}, Message: {message}");
            // Broadcast to all clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected: " + Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("Client disconnected: " + Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
