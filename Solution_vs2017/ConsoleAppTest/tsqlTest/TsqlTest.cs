using ConsoleAppTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class TsqlTest
	{
		public void Do()
		{
			//预插入1000条数据
			Random r = new Random();
			List<PersonModel> pList = new List<PersonModel>();
			for (int i = 1; i <= 1000; i++)
			{
				pList.Add(new PersonModel()
				{
					//Id = i,
					Name = "name" + i,
					Age = 15 + r.Next(20),
					Height = 160 + r.Next(20),
					Weight = 60 + r.Next(20)
				});
			}
			var flag= DAL.BaseDAL.BatchInsert(pList);
			Console.WriteLine($"批量插入状态：{flag}");
		}
	}
}
