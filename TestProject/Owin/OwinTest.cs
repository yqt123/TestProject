using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Owin
{
    public class OwinTest<T> : ITest
    {
        public void Execute()
        {
            using (WebApp.Start<T>("http://localhost:9093"))
            {
                Console.WriteLine("启动站点：http://localhost:9093");
                Console.ReadLine();
            }
        }
    }

    public class DefaultOwinTest : OwinTest<Startup>
    {

    }
}
