using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest.Test
{
	class HttpHelperTest
	{
		public void Do()
		{
			var result= HttpHelper.GetContent("https://hao.360.cn/");
		}
	}
}
