using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
 * 1.3 暂停线程(Thread.Sleep)
 */
namespace Ch01Recipe2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();

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

        /// <summary>
        /// 打印1-10数字(带延时)
        /// </summary>
        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }
}
