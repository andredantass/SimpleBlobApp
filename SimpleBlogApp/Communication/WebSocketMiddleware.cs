using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SimpleBlogApp.API.Communication
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;

        public WebSocketMiddleware(RequestDelegate next)
        {
            _next = next;
            ;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            CancellationToken ct = context.RequestAborted;

            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);

                return;
            }

            var currentWebSocket = await context.WebSockets.AcceptWebSocketAsync();
            WebSocketNotificationManager.Instance.AddSubscriberWs(currentWebSocket);

            await SendMessage(currentWebSocket, "Your has been connected");

            // keep the socket open until we get a cancellation request
            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }
            }

            
            await _next.Invoke(context);

        }

        private async Task SendMessage(WebSocket socket, string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
;        }
        private async Task Received(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handle)
        {
            var buffer = new ArraySegment<byte>(new Byte[1024 * 4]);
            WebSocketReceiveResult result = null;

            while (socket.State == WebSocketState.Open)
            {
                do
                {
                    result = await socket.ReceiveAsync(buffer, CancellationToken.None);

                } while (!result.EndOfMessage);

                var newBuffer = new byte[result.Count];
                Array.Copy(buffer.Array, newBuffer, result.Count);

                handle(result, newBuffer);
                Console.WriteLine(newBuffer.Length);
            }
        }
    }
}
