/*
 需要在OwinTest<TestProject.CrystalQuartz.Startup>启动
 */
using CrystalQuartz.Owin;
using Microsoft.Owin;
using Owin;
using Quartz;
using System;
using System.Diagnostics;

[assembly: OwinStartup(typeof(TestProject.CrystalQuartz.Startup))]
namespace TestProject.CrystalQuartz
{
    public class Startup
    {
        public static IScheduler scheduler;

        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/");
            app.UseErrorPage();
            //app.Run(context =>
            //{
            //    //将请求记录在控制台
            //    Trace.WriteLine(context.Request.Uri);
            //    //显示错误页
            //    if (context.Request.Path.ToString().Equals("/error"))
            //    {
            //        throw new Exception("抛出异常");
            //    }
            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello World");
            //});
            app.UseCrystalQuartz(() => scheduler);
        }
    }
}