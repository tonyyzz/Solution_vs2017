using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	public class ThreadPoolBase<T> where T : class
	{
		private ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
		public void Start(Action<T> action)
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				while (true)
				{
					Thread.Sleep(1);
					if (!queue.Any())
					{
						Thread.Sleep(400);
					}
					else
					{
						T obj = null;
						if (!queue.TryDequeue(out obj) || obj == null)
						{
							continue;
						}
						else
						{
							action(obj);
						}
					}
				}
			});
		}
		public void Enqueue(T obj)
		{
			queue.Enqueue(obj);
		}
	}
}
