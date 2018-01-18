using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class CSharpSeven
	{
		public void Do()
		{
			//var person = GetPersonInfo(56);
		}


		public static (int Id, string name, int age, int height) GetPersonInfo(int Id)
		{
			return (Id, "小红", 18, 160);
		}
	}
}
