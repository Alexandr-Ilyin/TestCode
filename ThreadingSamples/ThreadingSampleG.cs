
using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThreadingSamples
{
    public class ThreadingSampleG
    {
        [Test]
        public async Task RunSlowTask_Cancel()
        {
            var source = new CancellationTokenSource();
            source.CancelAfter(TimeSpan.FromSeconds(2));
            await SlowTask(source.Token);
            Console.WriteLine("Canceled...");
        }

        public async Task SlowTask(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("Thinking...");
                await Task.Delay(200);
            }
        }

    }
}