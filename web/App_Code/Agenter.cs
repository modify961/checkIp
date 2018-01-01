using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Agenter 的摘要说明
/// </summary>
public class Agenter
{
    public Agenter() { }
    public Agenter(String agenter) {
        String[] ipInfo = agenter.Split(',');
        if (ipInfo.Length ==3) {
            ip = ipInfo[0];
            int pot = 0;
            int.TryParse(ipInfo[1], out pot);
            port = pot;
            type = ipInfo[2];
            createTime = DateTime.Now.AddDays(8);
            checkTime = DateTime.Now.AddDays(8);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public ObjectId _id;
    /// <summary>
    /// IP地址
    /// </summary>
    public String ip { set; get; }
    /// <summary>
    /// 端口号
    /// </summary>
    public int port { set; get; }
    /// <summary>
    /// 是否可用
    /// </summary>
    public String type { set; get; }
    /// <summary>
    /// 存活时间（分钟）
    /// </summary>
    public int survibal { set; get; }
    /// <summary>
    /// 是否可用
    /// </summary>
    public bool usable { set; get; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime createTime { set; get; }
    /// <summary>
    /// 上次检查时间
    /// </summary>
    public DateTime checkTime { set; get; }
}