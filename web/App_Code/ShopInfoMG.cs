using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ShopInfoMG 的摘要说明
/// </summary>
public static class ShopInfoMG
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
            _mongoDatabase = mongodb.GetDatabase("dzdp");//选择数据库名
            _mongoCollection = _mongoDatabase.GetCollection<ShopInfo>("shopinfo");//选择集合，相当于表
            mongodb.Connect();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenters"></param>
    /// <returns></returns>
    public static int insert(List<ShopInfo> shopInfo)
    {
        var state = _mongoCollection.InsertBatch(shopInfo);
        return state.Count();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    /// <returns></returns>
    public static int insert(ShopInfo shopInfo)
    {
        if (!string.IsNullOrEmpty(shopInfo.shopId))
            return 0;
        var state = _mongoCollection.Insert(shopInfo);
        return 1;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List<ShopInfo> obtainAll()
    {

        return null;
    }
    /// <summary>
    /// 根据IP查询是否有重复IP
    /// </summary>
    /// <returns></returns>
    public static DiscussInfo obtainByIp(String ip)
    {

        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    public static void delete(ShopInfo shopInfo)
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    public static void delete()
    {
    }
    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="agenter"></param>
    public static void update(ShopInfo shopInfo)
    {

    }
}