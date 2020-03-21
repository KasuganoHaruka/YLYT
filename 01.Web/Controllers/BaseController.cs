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


        /// <summary>
        /// 当前用户信息
        /// </summary>
        public Account CurrentAccount { get; set; }


        /// <summary>
        /// 是否忽略Session检查
        /// </summary>
        public bool IgnoreSessionCheck { get; set; } = false;
    
    }
}