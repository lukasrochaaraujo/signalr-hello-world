using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hubNotification = new HubConnectionBuilder().WithUrl("https://localhost:5001/hub-notification").Build();
            
            hubNotification.On<string>("Event", message 
                => Console.WriteLine(message));

            await hubNotification.StartAsync();

            while (hubNotification.State == HubConnectionState.Connected)
                await Task.Delay(60000);
        }
    }
}
