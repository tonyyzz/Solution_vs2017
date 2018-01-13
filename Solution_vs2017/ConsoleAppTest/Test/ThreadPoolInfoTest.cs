using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class ThreadPoolInfoTest
	{
		public void Do()
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				while (true)
				{
					Thread.Sleep(400);
					ThreadPool.GetAvailableThreads(out int workThreads, out int completionPortThreads);
					Console.WriteLine($"{workThreads}，{completionPortThreads}");
					//ThreadPool.GetMaxThreads(out int workThreads, out int completionPortThreads);
					//Console.WriteLine($"{workThreads},{completionPortThreads}");
					//ThreadPool.GetMinThreads(out int workThreads, out int completionPortThread);
					//Console.WriteLine($"{workThreads},{completionPortThread}");
					Console.WriteLine(Thread.GetDomainID()); 
				}
			});

			Action<Thread> action = (thread) => { thread.IsBackground = true; thread.Start(); };
		}
	}
}
