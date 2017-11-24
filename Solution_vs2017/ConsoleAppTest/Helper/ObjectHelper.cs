using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	/// <summary>
	/// 对象帮助类
	/// </summary>
	public static class ObjectHelper
	{
		/// <summary>
		/// 对象深拷贝
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(this T obj) where T : class
		{
			return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
		}
	}
}
