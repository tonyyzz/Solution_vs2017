using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class DateTimeHelper
	{
		/// <summary>
		/// 输出默认格式的日期字符串（yyyy-MM-dd HH:mm:ss）
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public static string ToStr(this DateTime time)
		{
			return time.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}
