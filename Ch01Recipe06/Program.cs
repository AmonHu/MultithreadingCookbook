using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * 1.7 线程优先级(ThreadPriority)
 */
namespace Ch01Recipe6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Current thread priority: {Thread.CurrentThread.Priority}");

            Console.WriteLine("Running on all cores available");
            RunThreads();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            Console.WriteLine("Running on a single core");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();

            Console.ReadKey();

        }

        static void RunThreads()
        {
            var sample = new ThreadSample();

            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOne";

            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "ThreadTwo";

            threadOne.Priority = ThreadPriority.Highest;
            threadTwo.Priority = ThreadPriority.Lowest;
            
            threadOne.Start();
            threadTwo.Start();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();
        }

        class ThreadSample
        {
            private bool _isStopped = false;

            public void Stop()
            {
                _isStopped = true;
            }

            public void CountNumbers()
            {
                long counter = 10;

                while (!_isStopped)
                {
                    counter++;
                }

                Console.WriteLine($"{Thread.CurrentThread.Name} with " +
                    $"{Thread.CurrentThread.Priority,11} priority " +
                    $"has a count = {counter,13:N0}");
            }
        }
    }
}
