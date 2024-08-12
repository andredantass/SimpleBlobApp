using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogApp.Abstraction.Interface
{
    public interface IWebSocketManager
    {
        void AddSubscriberWs(WebSocket subscriber);
        Task SendClientNotification(string message);
    }
}
