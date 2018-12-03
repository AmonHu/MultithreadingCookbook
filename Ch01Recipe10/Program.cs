using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace Ch01Recipe10
{
    class Program
    {
        static void Main(string[] args)
        {
            object lock1 = new object();
            object lock2 = new object();

            new Thread(() => LockTooMuch(lock1, lock2)).Start();

            lock (lock2)
            {
                Sleep(1000);

                WriteLine("Monitor.TryEnter allows not to get stuck, returning false after a specified timeout is elapsed");

                if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
                {
                    WriteLine("Acquired a protected resource successfully");
                }
                else
                {
                    WriteLine("Timeout asquiring a resource");
                }
            }

            new Thread(() => LockTooMuch(lock1, lock2)).Start();

            WriteLine("----------------------------------------");

            lock (lock1)
            {
                WriteLine("This will be a deadlock");
                Sleep(1000);

                lock (lock2)
                {
                    WriteLine("Acquired a pretected resource successfully");
                }
            }

            ReadKey();
        }

        /// <summary>
        /// 锁定太多
        /// </summary>
        /// <param name="lock1">lock1</param>
        /// <param name="lock2">lock1</param>
        static void LockTooMuch(object lock1, object lock2)
        {
            lock (lock1)
            {
                Sleep(1000);
                lock (lock2);
            }
        }


    }
}
