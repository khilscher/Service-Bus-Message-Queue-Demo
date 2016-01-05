# Service-Bus-Message-Queue-Demo

Two sample console applications to demo Azure Service Bus Queues. 

In order for the above projects to run you will need to create an Azure Service Bus Queue using the Azure Portal (https://manage.windowsazure.com). Once you have created and configured the queue copy the connection strings from the Azure Portal. You will need to replace the connection string endpoint URLs and the queue name in the Program.cs file of each project. 

Queue Sender Project
Run this to create and place messages on the queue.

Queue Listener Project
Run this to create a listener to receive messages from the queue.



