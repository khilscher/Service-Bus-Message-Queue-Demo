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
            string queueName = "khqueue1";
            //Copy & paste receiver SB Queue endpoint from Azure portal; append TransportType=Amqp to use AMQP
            string connection = "Endpoint=sb://khtest1.servicebus.windows.net/;SharedAccessKeyName=Receiver;SharedAccessKey=vIqa5vlo9+c0YGxu+9xadEQ1aMUdwxgrcu2YCOqJNFw=;TransportType=Amqp";
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connection);
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
                        Console.WriteLine(message.GetBody<string>()); message.Complete();
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
