using System;
using System.Threading;


namespace Ch01Recipe1
{
    class Program
    {
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