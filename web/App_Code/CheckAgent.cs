using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// checkAgent 的摘要说明
/// </summary>
public class CheckAgent:IJob
{
    /// <summary>
    /// 执行检测进程程序
    /// </summary>
    /// <param name="context"></param>
    public void Execute(IJobExecutionContext context)
    {
        CheckThread checkThread = new CheckThread();
    }
}