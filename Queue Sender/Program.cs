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
            //e.g. "Endpoint=sb://<namespace>.servicebus.windows.net/;SharedAccessKeyName=Sender;SharedAccessKey=pSrZDMSw0cI6uQr6SuAVJzA+CmvauYocPA/1Y042xxx=;TransportType=Amqp"
            string connection = "";
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connection);
            QueueClient queue = factory.CreateQueueClient(queueName);
            string message = "Test message over AMQP";
            BrokeredMessage bm = new BrokeredMessage(message);
            bm.Properties.Add("Property1", "Value1");
            queue.Send(bm);
            Console.WriteLine("MessageId {0}", bm.MessageId);
            Thread.Sleep(3000);
        }
    }
}
