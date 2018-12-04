using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

/*
 * 1.4 线程等待(Thread.Join)
 */
namespace Ch01Recipe3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            t.Join();
            WriteLine("Thread completed");
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
