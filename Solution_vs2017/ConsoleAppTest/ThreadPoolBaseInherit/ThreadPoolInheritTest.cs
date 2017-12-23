using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	public class ThreadPoolInheritTest
	{
		public void Do()
		{
			ThreadPoolInherit.GetInstance().Start();
		}
	}
}
