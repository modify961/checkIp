using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// JobMG 的摘要说明
/// </summary>
public class JobMG
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
            _mongoDatabase = mongodb.GetDatabase("job");//选择数据库名
            _mongoCollection = _mongoDatabase.GetCollection<JobInfo>("jobs");//选择集合，相当于表
            mongodb.Connect();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenters"></param>
    /// <returns></returns>
    public static int insert(List<JobInfo> jobInfo)
    {
        var state = _mongoCollection.InsertBatch(jobInfo);
        return state.Count();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    /// <returns></returns>
    public static int insert(JobInfo jobInfo)
    {
        if (string.IsNullOrEmpty(jobInfo.name))
            return 0;
        if (obtainByIp(jobInfo.name)!=null)
            return 0;
        var state = _mongoCollection.Insert(jobInfo);
        return 1;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static List<JobInfo> obtainAll()
    {

        return null;
    }
    /// <summary>
    /// 根据IP查询是否有重复IP
    /// </summary>
    /// <returns></returns>
    public static JobInfo obtainByIp(String jobName)
    {
        IMongoQuery query = Query.EQ("name", jobName);
        object item = _mongoCollection.FindAs<Object>(query).FirstOrDefault();
        if (item != null)
        {
            return new JobInfo();
        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="agenter"></param>
    public static void delete(DiscussInfo discussInfo)
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
    public static void update(DiscussInfo discussInfo)
    {

    }
}