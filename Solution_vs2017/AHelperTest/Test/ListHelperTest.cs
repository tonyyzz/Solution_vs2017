using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest.Test
{
	class ListHelperTest
	{
		public void Do()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				list.Add(i + 1);
			}

			var li1 = list.GetRandomList();
		}
	}
}
