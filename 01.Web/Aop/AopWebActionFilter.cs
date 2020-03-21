using _01.Web.Controllers;
using _02.Entitys;
using _05.Toolkit.JwtToken;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace _01.Web.Aop
{

    /// <summary>
    /// 检查Session
    /// </summary>
    public class AopWebActionFilter : ActionFilterAttribute
    {

        private readonly ILogger<AopWebActionFilter> _logger;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public AopWebActionFilter(ILogger<AopWebActionFilter> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// 忽略特性
        /// </summary>
        public bool Ignore { get; set; } = true;

        /// <summary>
        /// 每次请求Action之前发生，，在行为方法执行前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var _RouteValues = context.ActionDescriptor.RouteValues;
            var _ControllerName = _RouteValues["controller"];
            var _ActionName = _RouteValues["action"];
            _logger.LogInformation($"AopWebActionFiter: {_ControllerName}Controller.{_ActionName}");

            if (!Ignore) return;
            var _Controller = context.Controller as BaseController;

            //如果没有忽略Session 检查
            if (!_Controller.IgnoreSessionCheck)
            {
                var tokenStr = context.HttpContext.Request.Headers["Authorization"];
                string jwtStr = tokenStr.ToString().Substring("Bearer ".Length).Trim();
                Account account = ((Account)RayPIMemoryCache.Get(jwtStr));

                if (account != null)
                {
                    _Controller.CurrentAccount = account;
                    _logger.LogInformation($"User_Name={account.User.User_Name},IsSuper={account.IsSuperManage}");
                }
                else
                {
                    var _LocationUrl = "www.sora.com";
                    var Alert = $@"<script type='text/javascript'>
                                        alert('登录信息验证失败');
                                        top.window.location='{_LocationUrl}';
                                    </script>";
                    _logger.LogInformation($"用户信息获取失败，跳转页面：{_LocationUrl}");
                    context.Result = _Controller.Content(Alert, "text/html;charset=utf-8;");
                }
            }
        }
    }
}