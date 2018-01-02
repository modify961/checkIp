
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MongoHelper 的摘要说明
/// </summary>
public static  class MongoHelper
{
    private static  MongoDatabase _mongoDatabase;
    private static  MongoCollection _mongoCollection;

    /// <summary>
    /// 
    /// </summary>
    public static void connection() {
        if (_mongoDatabase == null)
        {
            var settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("47.96.146.22", 27017);
            settings.WriteConcern = WriteConcern.Acknowledged;
            MongoServer mongodb = new MongoServer(settings);
            _mongoDatabase = mongodb.GetDatabase("AgentIp");//选择数据库名
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>("ipList");//选择集合，相当于表
            mongodb.Connect();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenters"></param>
    /// <returns></returns>
    public static int insert(List<Agenter> agenters) {
        var state=_mongoCollection.InsertBatch(agenters);
        return state.Count();
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
        foreach (var record in _mongoCollection.FindAllAs<Object>().ToList()) {
            Dictionary<String,Object> dictionary= record.ToBsonDocument().ToDictionary();
            agenters.Add(new Agenter() {
                ip= dictionary["ip"].ToString(),
                port=int.Parse( dictionary["port"].ToString()),
                type= !dictionary.ContainsKey("type")?"": dictionary["type"].ToString(),
                anonymous= !dictionary.ContainsKey("anonymous") ? "" : dictionary["anonymous"].ToString(),
                createTime =DateTime.Parse(dictionary["createTime"].ToString()),
                checkTime = DateTime.Parse(dictionary["checkTime"].ToString())
            });
        }
        return agenters;
    }
    /// <summary>
    /// 根据IP查询是否有重复IP
    /// </summary>
    /// <returns></returns>
    public static Agenter obtainByIp(String ip)
    {
        IMongoQuery query = Query.EQ("ip", ip);
        object item=_mongoCollection.FindAs<Object>(query).FirstOrDefault();
        if (item != null) {
            Dictionary<String, Object> dictionary = item.ToBsonDocument().ToDictionary();
            return new Agenter()
            {
                ip = dictionary["ip"].ToString(),
                port = int.Parse(dictionary["port"].ToString()),
                type = dictionary["type"] == null ? "" : dictionary["type"].ToString(),
                createTime = DateTime.Parse(dictionary["createTime"].ToString()),
                checkTime = DateTime.Parse(dictionary["checkTime"].ToString())
            };
        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    public static void delete(Agenter agenter) {
        IMongoQuery query = Query.EQ("ip", agenter.ip);
        _mongoCollection.Remove(query);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    public static void delete()
    {
        IMongoQuery query = Query.EQ("survibal",0);
        _mongoCollection.Remove(query);
    }
    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="agenter"></param>
    public static void update(Agenter agenter)
    {
        IMongoQuery query = Query.EQ("ip", agenter.ip);
        IMongoUpdate updateItem = Update.Set("checkTime", DateTime.Now.AddHours(8));
        _mongoCollection.Update(query, updateItem);
    }
}