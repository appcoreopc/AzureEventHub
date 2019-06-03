using System;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System.Threading.Tasks;


namespace EventReader
{
    class Program
    {

       private const string EventHubConnectionString = "Endpoint=sb://testehnstempdata.servicebus.windows.net/;SharedAccessKeyName=testapppolicy;SharedAccessKey=edt0qBfK7Tu3nPqNEDl2OHqhaTI0dgeH16GL5cJg6kI=;EntityPath=ehtesttargetapp";
        private const string EventHubName = "ehtesttargetapp";
        private const string StorageContainerName = "";
        private const string StorageAccountName = "sateststore";
        private const string StorageAccountKey = "E9Z0BUTEbahjyKRoBnCU/3XI3cxv2MynY3U+UuFMuwFVH5hE0w2tGN3N5rS/C5rjx9Ekmvz/AQtUVH4h3dpt2w==";
   
        private const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=sateststore;AccountKey=E9Z0BUTEbahjyKRoBnCU/3XI3cxv2MynY3U+UuFMuwFVH5hE0w2tGN3N5rS/C5rjx9Ekmvz/AQtUVH4h3dpt2w==;EndpointSuffix=core.windows.net";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!", args[0]);
            ReadEventData(args[0], args[1]).GetAwaiter().GetResult();
        }

        private static async Task ReadEventData(string containerName, string consumerGroup)         
        {
            Console.WriteLine($"Registering EventProcessor...to {containerName}");

            string consumergroup = string.Empty;

            if (consumerGroup == "default")
            {
                 consumerGroup = PartitionReceiver.DefaultConsumerGroupName;
            }          

            var eventProcessorHost = new EventProcessorHost(
                EventHubName,
                consumerGroup,
                EventHubConnectionString,
                StorageConnectionString,
                containerName);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press ENTER to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();


        }
    }
}
