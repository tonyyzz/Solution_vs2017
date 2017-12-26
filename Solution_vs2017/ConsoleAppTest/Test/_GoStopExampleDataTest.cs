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

			int pNum = 3;
			if (pNum == 2)
			{
				var CardHaveList1 = new List<int>() { 5, 13, 30, 4, 10, 18, 22, 38, 17, 21 }; //10张
				var CardHaveList2 = new List<int>() { 7, 11, 15, 19, 23, 27, 35, 2, 39, 44 }; //10张
				var CardShowList = new List<int>() { 6, 14, 31, 1, 26, 3, 34, 9 };  //8张
				var CardHideList = new List<int>() { }; //22张

				var RemoveDuplicatesList1 = CardHaveList1.Distinct();
				var RemoveDuplicatesList2 = CardHaveList2.Distinct();
				var RemoveDuplicatesList3 = CardShowList.Distinct();

				if (RemoveDuplicatesList1.Count() != CardHaveList1.Count())
				{
					throw new Exception("数字重复");
				}
				if (RemoveDuplicatesList2.Count() != CardHaveList2.Count())
				{
					throw new Exception("数字重复");
				}
				if (RemoveDuplicatesList3.Count() != CardShowList.Count())
				{
					throw new Exception("数字重复");
				}

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
				if (CardHideList.Count() != 22)
				{
					throw new Exception("个数不对");
				}
				var str11 = string.Join(",", CardHideList.ToArray());
				int mk = 0;
			}
			else if (pNum == 3)
			{
				var CardHaveList1 = new List<int>() { 5, 33, 25, 29, 1, 2, 3 }; //7张
				var CardHaveList2 = new List<int>() { 11, 9, 17, 7, 37, 15, 47 }; //7张
				var CardHaveList3 = new List<int>() { 44, 13, 21, 8, 10, 38, 16 }; //7张
				var CardShowList = new List<int>() { 4, 6, 12, 14, 34, 18 };  //6张
				var CardHideList = new List<int>() { }; //23张

				var RemoveDuplicatesList1 = CardHaveList1.Distinct();
				var RemoveDuplicatesList2 = CardHaveList2.Distinct();
				var RemoveDuplicatesList3 = CardHaveList3.Distinct();
				var RemoveDuplicatesList4 = CardShowList.Distinct();

				if (RemoveDuplicatesList1.Count() != CardHaveList1.Count())
				{
					throw new Exception("数字重复");
				}
				if (RemoveDuplicatesList2.Count() != CardHaveList2.Count())
				{
					throw new Exception("数字重复");
				}
				if (RemoveDuplicatesList3.Count() != CardHaveList3.Count())
				{
					throw new Exception("数字重复");
				}
				if (RemoveDuplicatesList4.Count() != CardShowList.Count())
				{
					throw new Exception("数字重复");
				}

				var intersection1 = CardHaveList1.Intersect(CardHaveList2).ToList();
				var intersection2 = CardHaveList1.Intersect(CardHaveList3).ToList();
				var intersection3 = CardHaveList1.Intersect(CardShowList).ToList();

				var intersection4 = CardHaveList2.Intersect(CardHaveList3).ToList();
				var intersection5 = CardHaveList2.Intersect(CardShowList).ToList();

				var intersection6 = CardHaveList3.Intersect(CardShowList).ToList();

				if (CardHaveList1.Count() != 7 || CardHaveList2.Count() != 7 || CardHaveList3.Count() != 7
					|| CardShowList.Count() != 6)
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
				if (intersection4.Any())
				{
					throw new Exception("intersection4");
				}
				if (intersection5.Any())
				{
					throw new Exception("intersection5");
				}
				if (intersection6.Any())
				{
					throw new Exception("intersection6");
				}

				var notHideLi = CardHaveList1.Concat(CardHaveList2).Concat(CardHaveList3).Concat(CardShowList).ToList();
				CardHideList = li.Except(notHideLi).ToList();
				if (CardHideList.Count() != 23)
				{
					throw new Exception("个数不对");
				}
				var str11 = string.Join(",", CardHideList.ToArray());

				int mk = 0;
			}


		}
	}
}
