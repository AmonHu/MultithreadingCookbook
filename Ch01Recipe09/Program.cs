using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Ch01Recipe9
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Incorrect counter");

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

            WriteLine($"Total count: {c.Count}");
            WriteLine("--------------------------------------------");

            WriteLine("Correct counter");

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
            WriteLine($"Total count: {c.Count}");

            ReadKey();
        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
    }

    /// <summary>
    /// Counter基类
    /// </summary>
    abstract class CounterBase
    {
        public abstract void Increment();
        public abstract void Decrement();
    }

    class Counter : CounterBase
    {
        /// <summary>
        /// 计数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 增加
        /// </summary>
        public override void Increment()
        {
            Count++;
        }

        /// <summary>
        /// 减小
        /// </summary>
        public override void Decrement()
        {
            Count--;
        }
    }

    class CounterWithLock : CounterBase
    {
        private readonly object _suncRoot = new object();
        public int Count { get; private set; }

        public override void Increment()
        {
            lock (_suncRoot)
            {
                Count++;
            }
            
        }

        public override void Decrement()
        {
            lock (_suncRoot)
            {
                Count--;
            }
        }
    }
}
