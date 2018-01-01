using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// IP检测线程
/// </summary>
public class CheckThread
{
    /// <summary>
    /// 
    /// </summary>
    public CheckThread()
    {
        Thread checks  = new Thread(new ThreadStart(checkIp));
        checks.Start();
    }
    /// <summary>
    /// 执行步骤为：
    /// 1：取出当前全部的代理IP。
    /// 2：循环遍历，当检测可用时更新检测日期
    /// 3：当不可用时直接删除
    /// </summary>
    public static void checkIp()
    {
        List<Agenter> agenters = MongoHelper.obtainAll();
        foreach (var agenter in agenters) {
            if (!AgentCheck.agentCheck(agenter))
            {
                MongoHelper.delete(agenter);
            }
            else {
                MongoHelper.update(agenter);
            }
        }
    }
}