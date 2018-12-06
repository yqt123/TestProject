using Microsoft.Owin;
using Owin;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestProject.Quartz
{
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            JobKey jobKey = context.JobDetail.Key;
            string msg = String.Format("SimpleJob says: {0} executing at {1}", jobKey, DateTime.Now.ToString("r"));
            Console.Out.WriteLineAsync(msg);
            return Task.FromResult(true);
        }

    }
}