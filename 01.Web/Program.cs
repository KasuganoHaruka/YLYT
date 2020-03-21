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
            //�������Nlog
            var logger = NLogBuilder.ConfigureNLog("Nlog/nlog.config").GetCurrentClassLogger();

            try
            {
                //����Nlog��־���
                logger.Debug("Debug init main");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "�����쳣��ֹͣ����");
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
