using _05.Toolkit;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DAL
{

    /// <summary>
    /// SqlServer SqlSugar
    /// 文档:http://www.codeisbug.com/Doc/8/1137
    /// </summary>
    public class SqlServerSqlSugar : ICoreDb
    {
        private readonly SqlSugarClient ICoreDbClient;
        private static string sqlConnectString = AppSettingManager.Configuration["AppConfig:SqlServerConnStr"];


        public SqlServerSqlSugar()
        {
            ICoreDbClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = sqlConnectString,//"server=.;uid=sa;pwd=elinks@123;database=CoreDB",
                DbType = DbType.SqlServer,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute, //从实体特性中读取主键自增列信息
                IsShardSameThread = true
            });
            //调式代码 用来打印SQL 
            ICoreDbClient.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    ICoreDbClient.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
        }

        public SqlSugarClient GetDbClient() { return ICoreDbClient; }

        //#region Insert

        //public bool Insert<T>(T ent) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().Insert(ent); }

        //public bool InsertRange<T>(T[] ents) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().InsertRange(ents); }
        //public int InsertReturnIdentity<T>(T ent) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().InsertReturnIdentity(ent); }

        //#endregion


        //#region Delete

        //public bool DeleteById<T>(string id) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().DeleteById(id); }

        //public bool Delete<T>(T ent) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().Delete(ent); }

        //public bool DeleteByIds<T>(string[] ids) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().DeleteByIds(ids); }

        //#endregion


        //#region Update

        //public bool Update<T>(T ent) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().Update(ent); }

        //public bool UpdateRange<T>(T[] ents) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().UpdateRange(ents); }

        //#endregion


        //#region Query

        //public List<T> GetList<T>() where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().GetList(); }

        //public List<T> GetPageList<T>(PageModel page) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().GetPageList(new List<IConditionalModel>(), page); }

        //public T GetById<T>(string id) where T : class, new() { return ICoreDbClient.GetSimpleClient<T>().GetById(id); }

        //#endregion
    }
}
