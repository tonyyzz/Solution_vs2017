using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class RandomListTest
	{
		public void Do()
		{
			var list = new List<int>();
			for (int i = 1; i <= 50; i++)
			{
				list.Add(i);
			}

			var list2 = GetRandomList(list);
		}
		/// <summary>
		/// list随机排序
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public static List<T> GetRandomList<T>(List<T> source)
		{
			if (!source.Any())
			{
				return null;
			}
			Random random = new Random();
			List<T> newList = new List<T>();
			foreach (T item in source)
			{
				newList.Insert(random.Next(newList.Count + 1), item);
			}
			return newList;
		}
	}
}
