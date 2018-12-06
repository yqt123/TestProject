/*
 参考地址
 https://github.com/guryanovev/CrystalQuartz
 https://blog.csdn.net/zhulongxi/article/details/52172769
 https://www.jianshu.com/p/f5118bd69d34
 */
namespace TestProject.CrystalQuartz
{
    public class CrystalQuartzTest : ITest
    {
        public void Execute()
        {
            Test.Execute<Quartz.QuartzTest>(false);
            Startup.scheduler = Quartz.QuartzTest.scheduler;
            Test.Execute<Owin.OwinTest<CrystalQuartz.Startup>>(false);
        }
    }
}
