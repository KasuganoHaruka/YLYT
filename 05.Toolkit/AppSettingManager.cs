using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Toolkit
{

    /// <summary>
    /// 固定读取根目录下Appsetting.json
    /// </summary>
    public  static class AppSettingManager
    {

        public static IConfiguration Configuration;

        static AppSettingManager() 
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }
    }
}
