using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class CookieTest
	{
		public void Do()
		{
			var cookieVal = CookieReader.GetCookie("https://pan.baidu.com/share/init?surl=ggr7GrT", "BAIDUID");
			
		}
	}
}
