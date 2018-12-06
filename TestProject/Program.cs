using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test.Execute<Quartz.QuartzTest>(); //Quartz测试
            //Test.Execute<Owin.DefaultOwinTest>(); //Owin测试
            Test.Execute<CrystalQuartz.CrystalQuartzTest>();//Quartz监控测试
        }
    }
}
