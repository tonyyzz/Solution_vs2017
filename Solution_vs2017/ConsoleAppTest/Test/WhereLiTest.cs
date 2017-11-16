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
			List<int> li = new List<int>() { 234, 657234, 12, 212 };
			var d = li.Where(m => 5 < 9).ToList();
		}
	}
}
