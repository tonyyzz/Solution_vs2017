using System;
using System.IO;
using System.Net;
using System.Text;

namespace System
{
	public class HttpHelper
	{
		#region post请求
		public static string GetContent(string url, string paramStrs, Encoding encoding)
		{
			Uri uri = new Uri(url);
			try
			{
				HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
				request.Method = "post";
				request.ContentType = "application/x-www-form-urlencoded";
				request.Headers.Add("Access-Control-Allow-Origin:*");
				string reqdata = paramStrs;
				byte[] buf = encoding.GetBytes(reqdata);
				Stream s = request.GetRequestStream();
				s.Write(buf, 0, buf.Length);
				s.Close();
				HttpWebResponse res = request.GetResponse() as HttpWebResponse;
				StreamReader sr = new StreamReader(res.GetResponseStream(), encoding);
				string html = sr.ReadToEnd();
				return html;
			}
			catch (Exception ex)
			{
				return ex.ToString();
			}
		}
		#endregion
	}
}
