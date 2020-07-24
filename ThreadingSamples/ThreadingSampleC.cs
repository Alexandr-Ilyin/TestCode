using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleC
    {
        SharedState state = new SharedState();

        [Test]
        public void Create_Threads_ShareStateWithoutLocks()
        {
            var thread1 = new Thread(new ThreadStart(RunOperation));

            var thread2 = new Thread(new ThreadStart(RunOperation));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        [Test]
        public void Create_Threads_ShareStateWithLocks()
        {
            var thread1 = new Thread(new ThreadStart(RunOperationWithLocks));

            var thread2 = new Thread(new ThreadStart(RunOperationWithLocks));
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        private void RunOperation()
        {
            for (int i = 0; i < 1000000; i++)
            {
                state.Values.Add("1");
                state.Values.Add("2");
                state.Values.Add("3");
                state.Values.Remove(state.Values[2]);
                state.Values.Remove(state.Values[1]);
                state.Values.Remove(state.Values[0]);
            }
        }

        private void RunOperationWithLocks()
        {
            try
            {

            
            for (int i = 0; i < 1000000; i++)
            {
                lock (state)
                {
                    state.Values.Add("1");
                    state.Values.Add("2");
                    state.Values.Add("3");
                    state.Values.Remove(state.Values[2]);
                    state.Values.Remove(state.Values[1]);
                    state.Values.Remove(state.Values[0]);
                }
            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public class SharedState
        {
            public List<string> Values { get; set; } = new List<string>();
        }
    }
}