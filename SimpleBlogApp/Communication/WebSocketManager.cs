using SimpleBlogApp.Abstraction.Interface;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace SimpleBlogApp.API.Communication
{
    public class WebSocketNotificationManager : IWebSocketManager
    {
        private static IWebSocketManager _instance;
        private static ConcurrentDictionary<string, WebSocket> _broadCastsWS = new ConcurrentDictionary<string, WebSocket>();
        public static IWebSocketManager Instance
        {
            get { return _instance ?? (_instance = new WebSocketNotificationManager()); }
            set { _instance = value; }
        }

        public void AddSubscriberWs(WebSocket subscriber)
        {
            var subscriberId = Guid.NewGuid().ToString();
            _broadCastsWS.TryAdd(subscriberId, subscriber);
        }

        public async Task SendClientNotification(string message)
        {
            foreach (var subscriber in _broadCastsWS)
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                await subscriber.Value.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
;            }
        }
    }
}
