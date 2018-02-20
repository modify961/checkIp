
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// ShopInfoMQ 的摘要说明
/// </summary>
public class ShopInfoMQ
{
    public void Receive()
    {
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
        channel.QueueDeclare(queue: "shops",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);
            ShopInfo shopInfo = JsonConvert.DeserializeObject<ShopInfo>(message.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            ShopInfoMG.insert(shopInfo);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };
        channel.BasicConsume(queue: "shops",
                             autoAck: false,
                             consumer: consumer);
        //}
    }
}