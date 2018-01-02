using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace ConsoleAppTest.Test
{
	class TimerTest
	{
		public void Do()
		{
			Timer timer = new Timer()
			{
				Interval = 1000,
				AutoReset = true,
				Enabled = true,
			};
			timer.Elapsed += (s, e) => { Console.WriteLine(DateTime.Now.ToStr()); };
			Console.WriteLine($"开始：{DateTime.Now.ToStr()}");
			timer.Start();
		}
	}
}
