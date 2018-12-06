using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Test
    {
        public static void Execute<T>(bool IsWait = true) where T : ITest
        {
            var task = System.Activator.CreateInstance<T>();
            task.Execute();
            if (IsWait)
                Console.ReadLine();
        }
    }
}
