using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class MultipleThreadPoolTest
	{
		public void Do()
		{
			for (int i = 0; i < 2; i++)
			{
				ThreadPool.QueueUserWorkItem(o =>
				{
					while (true)
					{
						Thread.Sleep(100 * ((int)o + 1));
						Console.WriteLine($"ThreadPool - {(int)o} {DateTime.Now.Ticks}");
					}
				}, i);
			}

		}
	}
}
