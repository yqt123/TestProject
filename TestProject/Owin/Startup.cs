using Microsoft.Owin;
using Owin;
using System;
using System.Diagnostics;

[assembly: OwinStartup(typeof(TestProject.Owin.Startup))]
namespace TestProject.Owin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Run(context =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello World");
            //});

            app.UseWelcomePage("/");
            app.UseErrorPage();
            app.Run(context =>
            {
                //将请求记录在控制台
                Trace.WriteLine(context.Request.Uri);
                //显示错误页
                if (context.Request.Path.ToString().Equals("/error"))
                {
                    throw new Exception("抛出异常");
                }
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello World");
            });
        }
    }
}