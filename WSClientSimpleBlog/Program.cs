using System.Net.WebSockets;
using System.Text;

Console.WriteLine("Press any key to connect with the websocket");
Console.ReadLine();

using (ClientWebSocket client = new ClientWebSocket())
{
    Uri serviceUrl = new Uri("wss://localhost:44309/connect");
    var token = new CancellationTokenSource();
    token.CancelAfter(TimeSpan.FromHours(1));

    try
    {
        await client.ConnectAsync(serviceUrl, token.Token);

        var responseBuffer = new byte[1024];
        var offSet = 0;
        var packet = 1024;


        while (client.State == WebSocketState.Open)
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(responseBuffer, offSet, packet);

            if (client.State == WebSocketState.Aborted)
            {
                Console.WriteLine("The connection with WebSocket was closed");
                break;
            }
            else
            {
                WebSocketReceiveResult response = await client.ReceiveAsync(buffer, token.Token);
                var responseMessage = Encoding.UTF8.GetString(responseBuffer, offSet, response.Count);

                Console.WriteLine(responseMessage);
                Thread.Sleep(2000);
            }
        }
    }
    catch (WebSocketException ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
Console.ReadLine();
