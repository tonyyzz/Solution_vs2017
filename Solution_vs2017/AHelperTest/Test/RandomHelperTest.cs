using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest.Test
{
	class RandomHelperTest
	{
		public void Do()
		{
			List<int> randomList = new List<int>();
			ListHelper.RandomNotEqualList(ref randomList, 1, 10, 3);
		}
	}
}
