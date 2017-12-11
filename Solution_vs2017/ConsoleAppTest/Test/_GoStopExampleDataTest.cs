using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class _GoStopExampleDataTest
	{
		public void Do()
		{
			List<int> li = new List<int>();
			for (int i = 1; i <= 50; i++)
			{
				li.Add(i);
			}
			var CardHaveList1 = new List<int>() { 1, 2, 3, 49, 50, 10, 14, 18, 22, 38 }; //10张
			var CardHaveList2 = new List<int>() { 7, 11, 15, 19, 23, 27, 31, 35, 39, 44 }; //10张
			var CardShowList = new List<int>() { 5, 26, 30, 34, 9, 13, 17, 21 };  //8张
			var CardHideList = new List<int>() { }; //22张

			var intersection1 = CardHaveList1.Intersect(CardHaveList2).ToList();
			var intersection2 = CardHaveList1.Intersect(CardShowList).ToList();
			var intersection3 = CardHaveList2.Intersect(CardShowList).ToList();

			if (intersection1.Any())
			{
				throw new Exception("intersection1");
			}
			if (intersection2.Any())
			{
				throw new Exception("intersection2");
			}
			if (intersection3.Any())
			{
				throw new Exception("intersection3");
			}

			var notHideLi = CardHaveList1.Concat(CardHaveList2).Concat(CardShowList).ToList();
			CardHideList = li.Except(notHideLi).ToList();
			var str11 = string.Join(",", CardHideList.ToArray());


			int mk = 0;
		}
	}
}
