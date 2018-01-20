using AHelperTest.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("启动...");
			new NetworkHelperTest().Do();
			Console.ReadKey();
		}
	}
}
