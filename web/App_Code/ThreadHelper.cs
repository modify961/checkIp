using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// ThreadHelper 的摘要说明
/// </summary>
public class ThreadHelper
{
    public ThreadHelper() {
        Thread t1 = new Thread(new ThreadStart(TestMethod));
        t1.Start();
    }
    /// <summary>
    /// 
    /// </summary>
    public static void TestMethod()
    {
        RabbitMQHelper.MQReceive mqReceive = new RabbitMQHelper.MQReceive();
        mqReceive.Receive();
    }
}