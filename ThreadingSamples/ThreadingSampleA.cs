using System;
using System.Threading;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleA
    {
        [Test]
        public void Create_Thread_Program_CrashesUnexpectedly()
        {
            var thread = new Thread(new ThreadStart(RunOperation));
            thread.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Done");
        }
        
        private void RunOperation()
        {
            throw new Exception("Some error in thread");
        }
    }
}