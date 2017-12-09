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
					Thread.Sleep(1);
					Console.WriteLine($"线程运行中...  {DateTime.Now.ToStr()}");
					
					if (true)
					{
						continue;
					}
				}
			});
		}
	}
}
