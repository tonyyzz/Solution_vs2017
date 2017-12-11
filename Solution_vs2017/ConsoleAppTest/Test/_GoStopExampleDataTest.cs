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
			var CardHaveList1 = new List<int>() { 5, 13, 30, 4, 10, 18, 22, 38, 17, 21 }; //10张
			var CardHaveList2 = new List<int>() { 7, 11, 15, 19, 23, 27, 35, 2, 39, 44 }; //10张
			var CardShowList = new List<int>() { 6, 14, 31, 1, 26, 3, 34, 9 };  //8张
			var CardHideList = new List<int>() { }; //22张

			var intersection1 = CardHaveList1.Intersect(CardHaveList2).ToList();
			var intersection2 = CardHaveList1.Intersect(CardShowList).ToList();
			var intersection3 = CardHaveList2.Intersect(CardShowList).ToList();

			if (CardHaveList1.Count() != 10 || CardHaveList2.Count() != 10 || CardShowList.Count() != 8)
			{
				throw new Exception("个数不对");
			}

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
