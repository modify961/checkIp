using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// QBaiMG 的摘要说明
/// </summary>
public class QBaiMG
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
            _mongoDatabase = mongodb.GetDatabase("qbais");//选择数据库名
            _mongoCollection = _mongoDatabase.GetCollection<QBaiInfo>("qbai");//选择集合，相当于表
            mongodb.Connect();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    /// <returns></returns>
    public static int insert(QBaiInfo qbaiInfo)
    {
        if (string.IsNullOrEmpty(qbaiInfo.info))
            return 0;
        if (obtainByIp(qbaiInfo.id) != null)
            return 0;
        if (obtainByIp(qbaiInfo.id)!=null)
            return 0;
        var state = _mongoCollection.Insert(qbaiInfo);
        return 1;
    }
    /// <summary>
    /// 根据IP查询是否有重复IP
    /// </summary>
    /// <returns></returns>
    public static QBaiInfo obtainByIp(String id)
    {
        IMongoQuery query = Query.EQ("id", id);
        object item = _mongoCollection.FindAs<Object>(query).FirstOrDefault();
        if (item != null)
        {
            return new QBaiInfo();
        }
        return null;
    }
}