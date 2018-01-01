using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQHelper
{
    public  class MQReceive
    {
        public  void Receive() {
            var factory = new ConnectionFactory() { HostName = "47.96.146.22" };
            factory.HostName = "47.96.146.22";
            factory.UserName = "ljw";
            factory.Password = "li809731496";
            factory.Port = 5672;
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
                channel.QueueDeclare(queue: "angentIp",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Agenter agernt = new Agenter(message.ToString());
                    if (AgentCheck.agentCheck(agernt)) {
                        MongoHelper.insert(agernt);
                    }
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: "angentIp",
                                     autoAck: false,
                                     consumer: consumer);
            //}
        }
    }
}
