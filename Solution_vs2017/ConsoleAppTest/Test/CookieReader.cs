using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class CookieReader
	{
		private const int INTERNET_COOKIE_HTTPONLY = 0x00002000;


		[DllImport("wininet.dll", SetLastError = true)]
		private static extern bool InternetGetCookieEx(
			string url,
			string cookieName,
			StringBuilder cookieData,
			ref int size,
			int flags,
			IntPtr pReserved);
		public static Dictionary<string, string> GetCookies(string url)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			int size = 5120;
			StringBuilder sb = new StringBuilder(size);
			if (!InternetGetCookieEx(url, null, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
			{
				if (size < 0)
				{
					return dict;
				}
				sb = new StringBuilder(size);
				if (!InternetGetCookieEx(url, null, sb, ref size, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero))
				{
					return dict;
				}
			}
			var chs = sb.ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var ch in chs)
			{
				var eqIndex = ch.IndexOf("=");
				dict.Add(ch.Substring(0, eqIndex), ch.Substring(eqIndex + 1));
			}
			return dict;
		}

		public static string GetCookie(string url, string cookieKey)
		{
			var val = GetCookies(url).FirstOrDefault(kvPair => kvPair.Key == cookieKey).Value;
			if (string.IsNullOrWhiteSpace(val))
			{
				val = "";
			}
			return val;
		}
	}
}
