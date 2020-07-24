using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleF
    {
        private AutoResetEvent pinged = new AutoResetEvent(false);
        private AutoResetEvent ponged = new AutoResetEvent(true);
        
        [Test]
        public void PingPong()
        {
            var thread1 = new Thread(new ThreadStart(Ping));

            var thread2 = new Thread(new ThreadStart(Pong));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            
        }

        
        public void Ping()
        {
            for (int i = 0; i < 5; i++)
            {
                ponged.WaitOne();
                Console.WriteLine("Ping");
                pinged.Set();
            }
        }
        
        public void Pong()
        {
            for (int i = 0; i < 5; i++)
            {
                pinged.WaitOne();
                Console.WriteLine("Pong");
                ponged.Set();
            }
        }
    }
}