﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch01Recipe9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In correct counter");

            var c = new Counter();

            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count:{0}",c.Count);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Correct counter");

            var c1 = new CounterWithLock();

            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count:{0}", c1.Count);

            Console.ReadKey();

        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }

        class Counter : CounterBase
        {
            public int Count { get; private set; }

            public override void Increment()
            {
                Count++;
            }

            public override void Decrement()
            {
                Count--;
            }
        }

        class CounterWithLock : CounterBase
        {
            private readonly  object _syncRoot = new object();

            public int Count { get; private set; }

            public override void Increment()
            {
                lock (_syncRoot)
                {
                    Count++;
                }
            }

            public override void Decrement()
            {
                lock (_syncRoot)
                {
                    Count--;
                }
            }
        }

        abstract class CounterBase
        {
            /// <summary>
            /// Increase
            /// </summary>
            public abstract void Increment();
            /// <summary>
            /// Decrease
            /// </summary>
            public abstract void Decrement();
        }
    }
}
