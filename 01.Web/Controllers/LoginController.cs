using System;
using System.Threading.Tasks;
using _02.Entitys;
using _02.Entitys.ORM;
using _03.Logic;
using _05.Toolkit.JwtToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quartz;

namespace _01.Web.Controllers
{

    /// <summary>
    /// 登录测试类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {

        private readonly ILogger<LoginController> _logger;
        private AccounttLogic _logic;

        public LoginController(ILogger<LoginController> logger, ISchedulerFactory schedulerFactory)
        {
            this._logger = logger;
            this._logic = new AccounttLogic();
            this._IgnoreSessionCheck = true;
        }


        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPwd"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<object> Login(string LoginName, string LoginPwd)
        {
            //var getByWhere = db.Queryable<Student>().Where(it => it.Id == 1 || it.Name == "a").ToList();

            var user = _DbClient.Queryable<Sys_User>().Where(p => p.User_LoginName == LoginName && p.User_Pwd == LoginPwd).First();

            if (user == null)
            {
                return new ResponseJson(StateEnum.Fail, "登录失败");
            }
            else
            {
                var token = JwtToken.IssueJWT(_logic.GetAccountByUser(user).Result, new TimeSpan(0, 60, 0), new TimeSpan(12, 00, 0));
                return token;
            }
        }


    }
}