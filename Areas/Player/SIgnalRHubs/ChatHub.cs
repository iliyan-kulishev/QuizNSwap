using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace QuizNSwap.Areas.Player.SIgnalRHubs
{
   /*The ChatHub class inherits from the SignalR Hub class. 
     The Hub class manages connections, groups, and messaging.

    The SendMessage method can be called by a connected client to send a message to all clients. 
    JavaScript client code that calls the method is shown later in the tutorial. 
    SignalR code is asynchronous to provide maximum scalability.
    */
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
