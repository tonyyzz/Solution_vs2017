using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class BaiduYun
	{
		public void Do()
		{
			//ThreadPool.QueueUserWorkItem(o => {
			//	while (true)
			//	{
			//		Thread.Sleep(100);
			//		var logid = getLogid();
			//		Console.WriteLine(logid);
			//	}
			//});




			string baiduyunLink = "https://pan.baidu.com/share/init?surl=kXeiAnt";
			string pwd = "qr6z";
			var result = getResult(baiduyunLink, pwd);

			var rObj = result.DeserializeObject<BaiduYunResult>();
			if (rObj.errno == 0)
			{
				Console.WriteLine($"破解成功，密码为：{pwd}");
			}
			else
			{
				Console.WriteLine($"密码错误");
			}
		}

		string getBaiduUId(string url)
		{
			return CookieReader.GetCookie(url, "BAIDUID");
		}

		public static string SendDataByGET(string Url, string surl, string postDataStr, string formParamStrs, ref CookieContainer cookie)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
			if (cookie.Count == 0)
			{
				request.CookieContainer = new CookieContainer();
				cookie = request.CookieContainer;
			}
			else
			{
				request.CookieContainer = cookie;
			}
			request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
			request.Method = "POST";
			request.KeepAlive = true;
			request.AllowAutoRedirect = true;

			request.Referer = $"https://pan.baidu.com/share/init?surl={surl}";
			request.Accept = "application/json, text/javascript, */*; q=0.01";
			request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
			request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
			request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
			request.Headers.Add("Cache-Control", "no-cache");
			request.Headers.Add("X-Requested-With", "XMLHttpRequest");
			request.Headers.Add("Origin", "https://pan.baidu.com");
			request.Headers.Add("Pragma", "no-cache");
			request.Host = "pan.baidu.com";
			string reqdata = formParamStrs;
			byte[] buf = System.Text.Encoding.UTF8.GetBytes(reqdata);
			System.IO.Stream s = request.GetRequestStream();
			s.Write(buf, 0, buf.Length);
			s.Close();
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			string encd = response.ContentEncoding;

			string htmlCode = "";
			using (System.IO.Stream streamReceive = response.GetResponseStream())
			{
				using (var zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
				{
					using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.UTF8))
					{
						htmlCode = sr.ReadToEnd();
					}
				}
			}

			return htmlCode;
		}


		string getResult(string baiduyunLink, string pwd)
		{
			var logid = getLogid(baiduyunLink);
			string surl = baiduyunLink.Split('?')[1].Split('=')[1];
			string postUrl = "https://pan.baidu.com/share/verify";
			string postParamstr = $"{baiduyunLink.Split('?')[1]}&t={getTime()}" +
				$"&bdstoken=null&channel=chunlei&clienttype=0&web=1&app_id=250528&logid={logid}";
			CookieContainer cookies = new CookieContainer();
			//cookies.Add(new Cookie("PANWEB", "1","/", ".pan.baidu.com"));
			//cookies.Add(new Cookie("PSINO", "5","/", ".baidu.com"));
			//cookies.Add(new Cookie("BAIDUID", "B1A24498D8F2EFF1156ECF13806B899C:FG=1", "/", ".baidu.com"));
			//cookies.Add(new Cookie("BIDUPSID", "B1A24498D8F2EFF1156ECF13806B899C", "/", ".baidu.com"));
			//cookies.Add(new Cookie("PSTM", "1514964941", "/", ".baidu.com"));
			var s = SendDataByGET(postUrl, surl, postParamstr, $"pwd={pwd}&vcode=&vcode_str=", ref cookies);
			return s;
		}

		public static string GetContent(string url, string paramStrs)
		{
			Uri uri = new Uri(url);
			try
			{
				HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
				request.Method = "post";
				request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
				request.Headers.Add("Access-Control-Allow-Origin:*");
				string reqdata = paramStrs;
				byte[] buf = System.Text.Encoding.UTF8.GetBytes(reqdata);
				System.IO.Stream s = request.GetRequestStream();
				s.Write(buf, 0, buf.Length);
				s.Close();
				HttpWebResponse res = request.GetResponse() as HttpWebResponse;
				StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
				string html = sr.ReadToEnd();
				return html;
			}
			catch (Exception ex)
			{
				return ex.ToString();
			}
		}

		public string getLogid(string referUrl)
		{
			var baiduUid = getBaiduUId(referUrl);
			return (string)ExecuteScript($"getLogid('{referUrl}')", getjsCode());
		}


		string getTime()
		{
			return (string)ExecuteScript("getTime()", getjsTime());

		}

		/// <summary>
		/// 执行JS
		/// </summary>
		/// <param name="sExpression">参数体</param>
		/// <param name="sCode">JavaScript代码的字符串</param>
		/// <returns></returns>
		private object ExecuteScript(string sExpression, string sCode)
		{
			MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
			scriptControl.UseSafeSubset = true;
			scriptControl.Language = "JScript";
			scriptControl.AddCode(sCode);
			try
			{
				return scriptControl.Eval(sExpression);
			}
			catch (Exception ex)
			{

			}
			return null;
		}

		string getjsTime()
		{
			return @"
function getTime() {
			return (new Date).getTime()+'';
		}
";
		}

		string getjsCode()
		{
			return @"
		function getLogid(baiduuid) {
			var s = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/~！@#￥%……&',
				u = String.fromCharCode,
				f = function (n) {
					if (n.length < 2) {
						var e = n.charCodeAt(0);
						return 128 > e ? n : 2048 > e ? u(192 | e >>> 6) + u(128 | 63 & e) : u(224 | e >>> 12 & 15) + u(128 | e >>> 6 & 63) + u(128 | 63 & e)
					}
					var e = 65536 + 1024 * (n.charCodeAt(0) - 55296) + (n.charCodeAt(1) - 56320);
					return u(240 | e >>> 18 & 7) + u(128 | e >>> 12 & 63) + u(128 | e >>> 6 & 63) + u(128 | 63 & e)
				},
				l = /[\uD800-\uDBFF][\uDC00-\uDFFFF]|[^\x00-\x7F]/g,

				d = function (n) {
					return (n + '' + Math.random()).replace(l, f)
				},
				g = function (n) {
					var e = [0, 2, 1][n.length % 3],
						o = n.charCodeAt(0) << 16 | (n.length > 1 ? n.charCodeAt(1) : 0) << 8 | (n.length > 2 ? n.charCodeAt(2) : 0),
						t = [s.charAt(o >>> 18), s.charAt(o >>> 12 & 63), e >= 2 ? '=' : s.charAt(o >>> 6 & 63), e >= 1 ? '=' : s.charAt(63 & o)];
					return t.join('')
				},
				m = function (n) {
					return n.replace(/[\s\S]{1,3}/g, g)
				},
				h = function () {
					return m(d((new Date).getTime()))
				},
				logid = h(String(baiduuid));
			return logid;
		}";
		}


	}




	public class BaiduYunResult
	{
		public int errno { get; set; }
		public string err_msg { get; set; }
		public long request_id { get; set; }
	}

}
