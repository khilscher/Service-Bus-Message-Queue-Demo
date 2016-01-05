using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;
using System.Threading;

namespace Queue_Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //Copy & paste SB queue name created in Azure portal
            string queueName = "khqueue1";
            //Copy & paste sender SB Queue endpoint from Azure portal; append TransportType=Amqp to use AMQP
            string connection = "Endpoint=sb://khtest1.servicebus.windows.net/;SharedAccessKeyName=Sender;SharedAccessKey=Uq3yCwF22HAvxL5RC85tRRWaLCLn7l1xZlAl1lPEuEA=;TransportType=Amqp";
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connection);
            QueueClient queue = factory.CreateQueueClient(queueName);
            string message = "Queue message over AMQP";
            BrokeredMessage bm = new BrokeredMessage(message);
            queue.Send(bm);
            Console.WriteLine("MessageId {0}", bm.MessageId);
            Thread.Sleep(3000);
        }
    }
}
