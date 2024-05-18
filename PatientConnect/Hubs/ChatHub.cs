using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using PatientConnect.Data;
using PatientConnect.Models;

namespace PatientConnect.Hubs;

public class ChatHub : Hub
{
    private readonly PatientConnectContext _context;
    private IDictionary<string, Connection> _connections;
    public ChatHub(PatientConnectContext context, IDictionary<string, Connection> connections)
    {
        _context = context;
        _connections = connections;
    }

    public async Task SendMessage(string roomId, string message)
    {
        // validate that user is part of the room
        HttpContext httpContext = Context.GetHttpContext();
        string user = httpContext.Session.GetString("Name");
        await Clients.Group(roomId).SendAsync("ReceiveMessage", user, message);
    }

    public async Task JoinRoom(Connection userConnection)
    {

        HttpContext httpContext = Context.GetHttpContext();
        string userName = httpContext.Session.GetString("Name");
        await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
        
        _connections[Context.ConnectionId] = userConnection;

        await Clients.Groups(userConnection.Room).SendAsync("ReceiveMessage", "SYSTEM MESSAGE", $"{userName} has joined {userConnection.Room}");

        await SendUsersConnected(userConnection.Room);
    }

    public Task SendUsersConnected(string room)
    {
        var users = _connections.Values.Where(u => u.Room == room);
        return Clients.Group(room).SendAsync("UsersInRoom", users);
    }
}