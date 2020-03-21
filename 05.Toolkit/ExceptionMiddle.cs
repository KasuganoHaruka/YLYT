using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _05.Toolkit
{

    /// <summary>
    /// 自定义全局异常捕获，这个中间件后面的所有代码都在 try catch里面 只要出发了异常  就会给当前中间件捕获（内部try catch的不会）
    /// </summary>
    public class ExceptionMiddl
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly IHostingEnvironment environment;

        public ExceptionMiddl(RequestDelegate next, ILogger<ExceptionMiddl> logger, IHostingEnvironment environment)
        {
            this.next = next;
            this.logger = logger;
            this.environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
                var features = context.Features;
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private async Task HandleException(HttpContext context, Exception e)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/json;charset=utf-8;";
            string user = "";
            string error = "";

            void ReadException(Exception ex)
            {
                error += string.Format("{0} | {1} | {2}", ex.Message, ex.StackTrace, ex.InnerException);
                if (ex.InnerException != null)
                {
                    ReadException(ex.InnerException);
                }
            }

            ReadException(e);
            var userJson = new { message = "抱歉，出错了" };
            var errorJson = new { message = "ExceptionMiddleWare Catch", detail = error };
            user = JsonConvert.SerializeObject(userJson);
            error = JsonConvert.SerializeObject(errorJson);

            if (environment.IsDevelopment())
                logger.LogError(error);
            else
                error = user;


            await context.Response.WriteAsync(error);
        }
    }
}
