using _02.Entitys;
using _05.Toolkit.JwtToken;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _01.Web.MiddleWare
{
    /// <summary>
    /// Token验证授权中间件
    /// </summary>
    public class TokenAuthMiddle
    {
        /// <summary>
        /// http委托
        /// </summary>
        private readonly RequestDelegate _next;
        private readonly ILogger<TokenAuthMiddle> _logger;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public TokenAuthMiddle(RequestDelegate next, ILogger<TokenAuthMiddle> logger)
        {
            _next = next;
            _logger = logger;
        }


        /// <summary>
        /// 验证授权
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("TokenAuth Begin");

            //如果在验证成功后写 Next,后续中间件throw Exception都会被这个try catch捕获,所以Next不能写在try中
            //写在最后又不能达到 验证失败 中断的效果，没有主动中断好难受
            bool IsNext = false;

            var headers = httpContext.Request.Headers;
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!headers.ContainsKey("Authorization"))
            {
                headers.Add("Authorization", "Bearer 这里添加避免后面获取账号抛出异常");
                IsNext = true;
            }
            else
            {
                var tokenStr = headers["Authorization"];
                try
                {
                    //验证缓存中是否存在该jwt字符串
                    string jwtStr = tokenStr.ToString().Substring("Bearer ".Length).Trim();
                    if (!RayPIMemoryCache.Exists(jwtStr))
                    {
                        _logger.LogInformation("非法请求");
                        await httpContext.Response.WriteAsync("非法请求");
                    }
                    else
                    {
                        _logger.LogInformation("刷新Token时间");

                        //TokenModel tm = ((TokenModel)RayPIMemoryCache.Get(jwtStr));
                        //Account account = JsonConvert.DeserializeObject<Account>(RayPIMemoryCache.Get(jwtStr).ToString());
                        var accountJson = RayPIMemoryCache.Get(jwtStr).ToString();

                       RayPIMemoryCache.AddMemoryCache(jwtStr, accountJson, new TimeSpan(0, 60, 0), new TimeSpan(12, 00, 0));

                        //提取tokenModel中的Sub属性进行authorize认证
                        //List<Claim> lc = new List<Claim>();
                        //Claim c = new Claim(account.User.User_Name + "Type", account.User.User_Name);
                        //lc.Add(c);
                        //ClaimsIdentity identity = new ClaimsIdentity(lc);
                        //ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        //httpContext.User = principal;

                        IsNext = true;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError($"TokenAuth Exception:{e.Message}");
                    await httpContext.Response.WriteAsync("token验证异常");
                }
            }

            _logger.LogInformation("TokenAuth End");

            if (IsNext)
            {
                await _next(httpContext);
            }

            _logger.LogInformation("TokenAuth Back");

        }
    }
}