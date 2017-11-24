using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class GuidTest
	{
		public void Do()
		{
			//GUID 32位字符串 可作为订单号
			var guidStr = Guid.NewGuid().ToString("N");
			int count = guidStr.Count();
		}
	}
}
