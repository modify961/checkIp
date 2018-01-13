using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// abandonIP 的摘要说明
/// </summary>
public class AbandonIP
{
    private static MongoDatabase _mongoDatabase;
    private static MongoCollection _mongoCollection;

    /// <summary>
    /// 
    /// </summary>
    public static void connection()
    {
        if (_mongoDatabase == null)
        {
            var settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("47.96.146.22", 27017);
            settings.WriteConcern = WriteConcern.Acknowledged;
            MongoServer mongodb = new MongoServer(settings);
            _mongoDatabase = mongodb.GetDatabase("AgentIp");//选择数据库名
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>("abandonIpList");//选择集合，相当于表
            mongodb.Connect();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    /// <returns></returns>
    public static int insert(Agenter agenter)
    {
        //判断如果不是IP的话返回
        if (agenter.ip.Split('.').Length != 4)
            return 0;
        var state = _mongoCollection.Insert(agenter);
        return 1;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List<Agenter> obtainAll()
    {
        List<Agenter> agenters = new List<Agenter>();
        foreach (var record in _mongoCollection.FindAllAs<Object>().ToList())
        {
            Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
            agenters.Add(new Agenter()
            {
                ip = dictionary["ip"].ToString(),
                port = int.Parse(dictionary["port"].ToString()),
                type = !dictionary.ContainsKey("type") ? "" : dictionary["type"].ToString(),
                anonymous = !dictionary.ContainsKey("anonymous") ? "" : dictionary["anonymous"].ToString(),
                createTime = DateTime.Parse(dictionary["createTime"].ToString()),
                checkTime = DateTime.Parse(dictionary["checkTime"].ToString())
            });
        }
        return agenters;
    }
}