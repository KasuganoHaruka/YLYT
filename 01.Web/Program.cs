using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace _01.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //这里添加Nlog
            var logger = NLogBuilder.ConfigureNLog("Nlog/nlog.config").GetCurrentClassLogger();

            try
            {
                //测试Nlog日志输出
                logger.Debug("Debug init main");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "由于异常而停止程序");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureLogging(logging => 
                    {
                        logging.SetMinimumLevel(LogLevel.Trace);
                    }).UseNLog();
                });
    }
}
