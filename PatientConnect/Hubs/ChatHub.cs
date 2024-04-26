using Microsoft.AspNetCore.SignalR;
using PatientConnect.Data;

namespace PatientConnect.Hubs;

public class ChatHub : Hub
{
    private readonly PatientConnectContext _context;
    public ChatHub(PatientConnectContext context) => _context = context;

    public async Task SendMessage(string user, string message)
    {
        Console.WriteLine($"{user}: {message}");
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}