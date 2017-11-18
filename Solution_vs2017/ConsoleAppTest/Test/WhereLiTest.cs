using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class WhereLiTest
	{
		public void Do()
		{
			List<int> list = new List<int>() { 234, 657234, 12, 212 };
			var d = list.Where(m => 5 < 9).ToList();
			var g = list.FirstOrDefault();

			 list.Sort((m, n) => m - n);
		}
	}
}
