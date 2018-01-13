using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// IP接收线程数据接收线程
/// </summary>
public class ReceiveThread
{
    public ReceiveThread() {
        Thread t1 = new Thread(new ThreadStart(receiveIp));
        t1.Start();
    }
    /// <summary>
    /// 
    /// </summary>
    public static void receiveIp()
    {
        
    }
}