using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;
using System;
 
namespace EventWriter
{
    class Program
    {
        private const string EventHubConnectionString = "Endpoint=sb://testehnstempdata.servicebus.windows.net/;SharedAccessKeyName=testapppolicy;SharedAccessKey=edt0qBfK7Tu3nPqNEDl2OHqhaTI0dgeH16GL5cJg6kI=;EntityPath=ehtesttargetapp";
        private const string EventHubName = "ehtesttargetapp";


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
