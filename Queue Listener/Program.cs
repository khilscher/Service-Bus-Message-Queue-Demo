using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus.Messaging;

namespace Queue_Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            //Copy & paste SB queue name created in Azure portal
            string queueName = "khqueue1";
            //Copy & paste receiver SB Queue endpoint from Azure portal; append TransportType=Amqp to use AMQP
            //e.g. "Endpoint=sb://<namespace>.servicebus.windows.net/;SharedAccessKeyName=Receiver;SharedAccessKey=53qmlfuqiEzHHOkzW5C7CaXzlGzjs0ugA9f7OrDWzDDd;TransportType=Amqp"
            string connection = "";
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connection);

            //Default receive mode is PeekLock. 
            //https://docs.microsoft.com/en-us/dotnet/api/microsoft.servicebus.messaging.receivemode
            //https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-fundamentals-hybrid-solutions
            QueueClient queue = factory.CreateQueueClient(queueName);

            while (true)
            {
                BrokeredMessage message = queue.Receive();

                if (message != null)
                {
                    try
                    {
                        Console.WriteLine("MessageId {0}", message.MessageId);
                        Console.WriteLine("Delivery {0}", message.DeliveryCount);
                        Console.WriteLine("Size {0}", message.Size);
                        Console.WriteLine(message.GetBody<string>()); message.Complete(); //Queue will now delete the message
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        message.Abandon();
                    }
                }
            }
        }
    }
}
