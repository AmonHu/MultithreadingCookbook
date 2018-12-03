using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Ch01Recipe4
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting progam...");
            Thread t = new Thread(PrintNumbersWithDelay);
            t.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t.Abort();
            WriteLine("A thread has been aborted");

            Thread t1 = new Thread(PrintNumbers);
            t1.Start();
            PrintNumbers();

            ReadKey();
        }


        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }

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
