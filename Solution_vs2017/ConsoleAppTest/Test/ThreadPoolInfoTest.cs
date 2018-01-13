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
			int threadCount = 30;
			for (int i = 0; i < threadCount; i++)
			{
				Console.WriteLine(i);
				ThreadPool.QueueUserWorkItem(o =>
				{
					while (true)
					{
						Thread.Sleep(100);
						ThreadPool.GetAvailableThreads(out int workThreads, out int completionPortThreads);
						Console.WriteLine($"{workThreads}，{completionPortThreads}");
						//ThreadPool.GetMaxThreads(out int workThreads, out int completionPortThreads);
						//Console.WriteLine($"{workThreads},{completionPortThreads}");
						//ThreadPool.GetMinThreads(out int workThreads, out int completionPortThread);
						//Console.WriteLine($"{workThreads},{completionPortThread}");
						//Console.WriteLine(Thread.GetDomainID()); 
					}
				});
			}
			

			//Action<Thread> action = (thread) => { thread.IsBackground = true; thread.Start(); };
		}
	}
}
