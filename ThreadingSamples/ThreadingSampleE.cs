using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleE
    {
        private object valueA = new Object();
        private object valueB = new Object();
        
        [Test]
        public void Create_DeadLock()
        {
            var thread1 = new Thread(new ThreadStart(Operation1));

            var thread2 = new Thread(new ThreadStart(Operation2));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            
        }

        
        public void Operation1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Operation1 . Waiting A");
            lock (valueA)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Operation1 . Waiting B");
                lock (valueB)
                {
                    Console.WriteLine("Operation 1");
                }
            }
        }
        
        public void Operation2()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Operation2 . Waiting B");
            lock (valueB)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Operation2 . Waiting A");
                lock (valueA)
                {
                    Console.WriteLine("Operation 2");
                }
            }
        }
    }
}