using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;
using System;
 
namespace EventWriter
{
    class Program
    {

        private static EventHubClient eventHubClient;
        private const string EventHubConnectionString = "{Event Hubs connection string}";
        private const string EventHubName = "{Event Hub path/name}";


        static void Main(string[] args)
        {            
            Console.WriteLine("Hello World!");
            SendAsync().GetAwaiter().GetResult();
        }


        private static async Task SendAsync()
        {
            var client = EventHubClient.CreateFromConnectionString(EventHubConnectionString);
            
            for (int i = 0; i < 100; i++)
            {
                 byte[] dataMessage = Encoding.UTF8.GetBytes("Sending fake message" + i);

                var fakeEventMessage = new EventData(dataMessage);
                await  client.SendAsync(fakeEventMessage);
            }
        }
     }
}
