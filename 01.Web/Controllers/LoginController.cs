using System;
using System.Threading.Tasks;
using _02.Entitys;
using _02.Entitys.ORM;
using _03.Logic;
using _04.DAL;
using _05.Toolkit.JwtToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _03.Logic.Interface;

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
        private IBaseLogic _logic;


        public LoginController(ILogger<LoginController> logger, IBaseLogic baseLogic)
        {
            this._logger = logger;
            this._logic = baseLogic;
            this.IgnoreSessionCheck = true;
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

            var user = _logic.GetDbClient().Queryable<Sys_User>().Where(p => p.User_LoginName == LoginName && p.User_Pwd == LoginPwd).First();

            if (user == null)
            {
                return new ResponseJson(StateEnum.Fail, "登录失败");
            }
            else
            {
                var _RoleList = _logic.GetDbClient().Queryable<Sys_UserRole>().Where(m1 => m1.UserRole_UserID == user.User_ID).Select(m1 => m1.UserRole_RoleID).ToList();
                CurrentAccount = new Account
                {
                    RoleIDList = _RoleList,
                    User = user,
                    IsSuperManage = false
                };

                var token = JwtToken.IssueJWT(CurrentAccount, new TimeSpan(0, 60, 0), new TimeSpan(12, 00, 0));
                return token;
            }
        }


    }
}