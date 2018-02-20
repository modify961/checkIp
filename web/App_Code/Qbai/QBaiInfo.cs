using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// QBaiInfo 的摘要说明
/// </summary>
[Serializable]
public class QBaiInfo
{

    /// <summary>
    /// ID
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 内容
    /// </summary>
    public string info { get; set; }
    /// <summary>
    /// 好笑数
    /// </summary>
    public int silmeNum { get; set; }
    /// <summary>
    /// 来源
    /// </summary>
    public string from { get; set; }
}