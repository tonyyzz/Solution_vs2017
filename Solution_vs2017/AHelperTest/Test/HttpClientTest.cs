using iGdou.Collection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest.Test
{
	class HttpClientTest
	{
		public void Do()
		{
			HttpClient httpClient = new HttpClient();
			var task= httpClient.GetResponse("https://hao.360.cn/");
			var str = task.Result;
		}
	}
}
