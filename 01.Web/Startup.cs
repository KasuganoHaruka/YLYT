using System;
using System.IO;
using _01.Web.MiddleWare;
using _03.Logic;
using _03.Logic.Interface;
using _03.Logic.Sys;
using _04.DAL;
using _05.Toolkit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;

namespace _01.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "YLYT.Core",
                    Description = "����.NET Core 3.1 �������",
                    Contact = new OpenApiContact
                    {
                        Name = "����",
                        Email = "906369225@qq.com",
                        Url = new Uri("http://www.Sora.com"),
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "���¿�����������ͷ����Ҫ���Jwt��ȨToken��Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                //���һ�������ȫ�ְ�ȫ��Ϣ����AddSecurityDefinition����ָ���ķ�������Ҫһ�£�������Bearer��
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                //���ע�ͷ���
                var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var webxmlPath = Path.Combine(basePath, "WebApi.xml");
                var entitysxmlPath = Path.Combine(basePath, "EntitysApi.xml");
                c.IncludeXmlComments(webxmlPath, true);
                c.IncludeXmlComments(entitysxmlPath, true);

            });
            #endregion

            #region JwtToken
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());
                options.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());
                options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());
            });
            #endregion

            services.AddScoped(typeof(ICoreDb), typeof(SqlServerSqlSugar));
            services.AddScoped(typeof(IBaseLogic), typeof(BaseLogic));
            services.AddScoped(typeof(IMenuLogic), typeof(MenuLogic));


            #region Cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", policy =>
                {
                    policy.AllowAnyOrigin()//�����κ�Դ
                    .AllowAnyMethod()//�����κη�ʽ
                    .AllowAnyHeader()//�����κ�ͷ
                    .AllowCredentials();//����cookie
                });
                c.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:8083")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("authorization");
                });
            });
            #endregion


            #region Quartz
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "YLYT.Core");
            });

            //�Զ���ȫ���쳣����
            app.UseMiddleware<ExceptionMiddl>();
            //Token��֤
            app.UseMiddleware<TokenAuthMiddle>();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
