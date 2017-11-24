using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class ThreadPoolTest
	{
		public void Do()
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				while (true)
				{
					Console.WriteLine($"线程运行中...  {DateTime.Now.ToStr()}");

					Thread.Sleep(1);
					if (true)
					{
						continue;
					}
				}
			});

			//new Thread(m =>
			//{
			//		while (true)
			//		{
			//			Console.WriteLine($"线程运行中...  {DateTime.Now.ToStr()}");

			//			Thread.Sleep(1);
			//			if (true)
			//			{
			//				continue;
			//			}
			//		}
			//})
			//{ IsBackground = true, Priority = ThreadPriority.Highest }.Start();

		}
	}
}
