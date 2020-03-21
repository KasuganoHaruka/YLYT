using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01.Web.Aop;
using _02.Entitys;
using _04.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SqlSugar;

namespace _01.Web.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [TypeFilter(typeof(AopWebActionFilter))]
    public class BaseController : ControllerBase
    {
        ///// <summary>
        ///// 数据访问对象，注入的方式
        ///// </summary>
        ///// <param name="dbContext"></param>
        //public BaseController(IDbContext dbContext)
        //{
        //    this.DbContext = dbContext;
        //}
        //public IDbContext DbContext;

        /// <summary>
        /// 数据访问对象
        /// </summary>
        public SqlSugarClient _DbClient => new SqlSugarDbContext().DbClient;


        /// <summary>
        /// 当前用户信息
        /// </summary>
        public Account _Account { get; set; } = new Account();


        /// <summary>
        /// 是否忽略Session检查
        /// </summary>
        public bool _IgnoreSessionCheck { get; set; } = false;


    
    }
}