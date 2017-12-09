using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	public class ListTest
	{
		public void Do()
		{
			List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> list2 = new List<int>() { 3, 4, 5, 6, 7 };
			var flag = list.All(m => m > 1);
			var readOnlyList = list.AsReadOnly();
			var average = list.Average(m => m + 1);
			var i = list.BinarySearch(4);
			//var d =  list.Cast<string>().ToList();
			var groupList = list.GroupBy(m => m % 2 == 0, (m, li) => li).ToList();
			var groupJoinLi = list.GroupJoin(list2, (m) => m, (m) => m, (m, li) => li).ToList();
		}
	}
}
