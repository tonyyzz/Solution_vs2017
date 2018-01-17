using System;
using System.IO;

namespace Auction.Utility.Utils
{
	public class NetworkUtils
	{
		public static string GetIP()
		{
			//重复获取n次
			int index = 1;
			string ipStr = "";
			while (index <= 10)
			{
				try
				{
					Uri uri = new Uri("http://city.ip138.com/ip2city.asp");
					System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
					req.Method = "get";
					using (Stream s = req.GetResponse().GetResponseStream())
					{
						using (StreamReader reader = new StreamReader(s))
						{
							char[] ch = { '[', ']' };
							string str = reader.ReadToEnd();
							System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(str, @"\[(?<IP>[0-9\.]*)\]");
							ipStr = m.Value.Trim(ch);
							break;
						}
					}
				}
				catch (Exception)
				{
					index += 1;
				}
			}
			return ipStr;

		}

		/// <summary>
		/// 根据ip地址获取城市信息
		/// </summary>
		/// <param name="ipAddress"></param>
		public static NetCityInfo GetCityInfo(string ipAddress)
		{
			string result = ResponseUtils.GetContent("http://int.dpool.sina.com.cn/iplookup/iplookup.php?" + string.Format(@"format=json&ip={0}", ipAddress), "");
			return JsonUtils.Deserialize<NetCityInfo>(result);
		}

		/// <summary>
		/// 网络城市信息
		/// </summary>
		public class NetCityInfo
		{
			public string country { get; set; }
			public string province { get; set; }
			public string city { get; set; }
		}

	}
}
