using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.DAL
{
    //如果用注入的方式,就要用到接口
    public interface IDbContext 
    {
        SqlSugarClient DbClient { get;}
    }

    /// <summary>
    /// SqlSugar
    /// 文档:http://www.codeisbug.com/Doc/8/1137
    /// </summary>
    public class SqlSugarDbContext //: IDbContext
    {
        //注意：不能写成静态的，不能写成静态的
        public SqlSugarClient DbClient;

        public SqlSugarDbContext()
        {

            DbClient = new SqlSugarClient(new ConnectionConfig()
            {
               ConnectionString = "server=.;uid=sa;pwd=elinks@123;database=CoreDB",
               DbType = DbType.SqlServer,//设置数据库类型
               IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute, //从实体特性中读取主键自增列信息
                IsShardSameThread = true
            });
            //调式代码 用来打印SQL 
            DbClient.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    DbClient.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };


            //var getByWhere = db.Queryable<Student>().Where(it => it.Id == 1 || it.Name == "a").ToList();


        }

    }
}
