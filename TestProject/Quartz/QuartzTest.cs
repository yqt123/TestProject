using Microsoft.Owin.Hosting;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Quartz
{
    public class QuartzTest : ITest
    {
        public static IScheduler scheduler;
        public void Execute()
        {
            var properties = new NameValueCollection();
            //properties["quartz.scheduler.instanceName"] = "RemoteServerSchedulerClient";

            //// 设置线程池
            //properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            //properties["quartz.threadPool.threadCount"] = "5";
            //properties["quartz.threadPool.threadPriority"] = "Normal";

            //// 远程输出配置
            //properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            //properties["quartz.scheduler.exporter.port"] = "556";
            //properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
            //properties["quartz.scheduler.exporter.channelType"] = "tcp";
            
            properties["quartz.scheduler.instanceName"] = "DefaultQuartzScheduler";
            properties["quartz.scheduler.instanceId"] = "instance_one";
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";
            properties["quartz.serializer.type"] = "binary";

            properties["quartz.jobStore.misfireThreshold"] = "60000";
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";

            properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.MySQLDelegate, Quartz";
            properties["quartz.jobStore.useProperties"] = "false";
            properties["quartz.jobStore.dataSource"] = "myDS";

            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            properties["quartz.jobStore.clustered"] = "true";
            // if running MS SQL Server we need this
            properties["quartz.jobStore.selectWithLockSQL"] = "SELECT * FROM {0}LOCKS UPDLOCK WHERE LOCK_NAME = @lockName";

            properties["quartz.dataSource.myDS.connectionString"] = @"Database='quartz';Data Source='127.0.0.1';User Id='dev';Password='dev123';charset='utf8';pooling=true;Allow Zero Datetime=True";
            properties["quartz.dataSource.myDS.provider"] = "MySql";
            //
            var schedulerFactory = new StdSchedulerFactory(properties);
            //var scheduler = schedulerFactory.GetScheduler();
            scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            //var job = JobBuilder.Create<TestJob>()
            //    .WithIdentity("myJob", "group1")
            //    .Build();

            //var trigger = TriggerBuilder.Create()
            //    .WithIdentity("myJobTrigger", "group1")
            //    .StartNow()
            //    .WithCronSchedule("/10 * * ? * *")
            //    .Build();

            //scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

        }
    }
}
