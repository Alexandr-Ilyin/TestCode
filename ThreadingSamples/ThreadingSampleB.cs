using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleB
    {
        [Test]
        public async Task Create_Task_Wait_Incorrectly()
        {
            await RunOperation1();
            Thread.Sleep(100);
            await RunOperation1();
        }
        
        [Test]
        public async Task Create_Task_Wait_Correctly()
        {
            await RunOperation1();
            await Task.Delay(100);
            await RunOperation1();
        }

        private async Task RunOperation1()
        {
        }

        private async Task RunOperation2()
        {
        }
    }
}