using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatterWeb
{
    public class ChatHub : Hub
    {
        public void RegisterUser(string name)
        {
            Clients.Caller.name = name;
            Clients.All.broadcastMessage("Server", string.Format("{0} joined the chat.", name));
        }

        public void Send(string message)
        {
            Clients.All.broadcastMessage(Clients.Caller.name, message);
        }
    }
}