using ConsoleAppTest.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"测试中...");

			new ThreadPoolInheritTest().Do();
			
			Console.ReadKey(); 
		}
	}
}
