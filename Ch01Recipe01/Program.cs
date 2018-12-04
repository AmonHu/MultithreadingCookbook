using System;
using System.Threading;

/*
 * 1.2 使用C#创建线程
 */

namespace Ch01Recipe1
{
    class Program
    {
        /// <summary>
        /// Main函数
        /// </summary>
        /// <param name="args">系统参数</param>
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            Thread t = new Thread(PrintNumbers);
            //Thread t1 = new Thread(PrintNumbers);
            t.Start();
            
            //t1.Start();
           PrintNumbers();

            Console.ReadKey();
        }

        /// <summary>
        /// 打印1-10数字
        /// </summary>
        static void PrintNumbers()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}