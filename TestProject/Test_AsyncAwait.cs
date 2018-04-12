using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Test_AsyncAwait
    {
        public static void Execute()
        {
            var result = MyMethod(); //将异步执行
            //Console.WriteLine(result.Result); //比方法1多了一行
            Console.WriteLine("end");
            Console.ReadLine();
        }

        static async Task<int> MyMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                //await Task.Delay(1000); //模拟耗时操作

                //await TestMethod();

                await Task.Run(TestMethod);

                Console.WriteLine("异步执行" + i.ToString() + "..");
            }
            return 0;
        }

        static Task TestMethod()
        {
            //死循环，永远执行
            while (true)
            {

            }
        }

        static void TestMethod2()
        {

        }

    }
}
