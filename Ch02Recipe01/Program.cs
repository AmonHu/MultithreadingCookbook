using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ch02Recipe01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Incorrect counter");

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

            Console.WriteLine("Total count: {0}", c.Count);
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("Correct counter");
            var c1 = new CounterNoLock();

            t1 = new Thread(() => TestCounter(c));
            t2 = new Thread(() => TestCounter(c));
            t3 = new Thread(() => TestCounter(c));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total count: {0}", c.Count);
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
            /// <summary>
            /// 计数器
            /// </summary>
            private int _count;

            /// <summary>
            /// 计数器
            /// </summary>
            public int Count
            {
                get { return _count; }
            }

            /// <summary>
            /// 增加
            /// </summary>
            public override void Increment()
            {
                _count++;
            }

            /// <summary>
            /// 减少
            /// </summary>
            public override void Decrement()
            {
                _count--;
            }
        }

        /// <summary>
        /// 没有锁定的计数类
        /// </summary>
        class CounterNoLock : CounterBase
        {
            /// <summary>
            /// 计数器
            /// </summary>
            private int _count;

            /// <summary>
            /// 计数器
            /// </summary>
            public int Count
            {
                get { return _count; }
            }

            /// <summary>
            /// 增加
            /// </summary>
            public override void Increment()
            {
                Interlocked.Increment(ref _count);
            }

            /// <summary>
            /// 减少
            /// </summary>
            public override void Decrement()
            {
                Interlocked.Decrement(ref _count);
            }
        }

        abstract class CounterBase
        {
            /// <summary>
            /// 增加
            /// </summary>
            public abstract void Increment();
            /// <summary>
            /// 减少
            /// </summary>
            public abstract void Decrement();
        }
    }
}
