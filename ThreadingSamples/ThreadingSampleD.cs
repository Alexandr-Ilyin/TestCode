using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleD
    {
        [Test]
        public void Create_Task_DoNot_Await()
        {
            SomeOperation();
            Console.WriteLine("Test Finished");
        }

        
        public async Task SomeOperation()
        {
            Console.WriteLine("Started...");
            await Task.Delay(2000);
            Console.WriteLine("Finished...");
            
        }
    }
}