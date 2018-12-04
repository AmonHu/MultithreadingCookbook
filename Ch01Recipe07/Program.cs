using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * 1.8 前台线程和后台线程(Thread.IsBackground)
 */
namespace Ch01Recipe7
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleForeground = new ThreadSample(10);
            var sampleBackground = new ThreadSample(20);

            var threadOne = new Thread(sampleForeground.CountNumbers);
            threadOne.Name = "ForegroundThread";
            var threadTwo = new Thread(sampleBackground.CountNumbers);
            threadTwo.Name = "BackgroundThread";
            threadTwo.IsBackground = true;

            threadOne.Start();
            threadTwo.Start();

            //Console.ReadKey();
        }

        class ThreadSample
        {
            private readonly int _iterations;

            public ThreadSample(int iterations)
            {
                _iterations = iterations;
            }

            public void CountNumbers()
            {
                for (int i = 0; i < _iterations; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));

                    Console.WriteLine($"{Thread.CurrentThread.Name} prints {i}");
                }
            }
        }
    }

    
}
