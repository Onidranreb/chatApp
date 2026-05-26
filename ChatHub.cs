using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        // This method receives a message from one phone and broadcasts it to everyone else
        public async Task SendMessage(string user, string message, string targetClient)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, targetClient);
        }
    }
}