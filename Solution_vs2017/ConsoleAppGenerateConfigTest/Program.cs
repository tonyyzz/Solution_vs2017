using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGenerateConfigTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string str = "a";
#if DEBUG
			str = "DEBUG";
#elif TESTCONFIG
			str = "TESTCONFIG";
#else
			str = "RELEASE";
#endif
			Console.WriteLine(str);
			Console.ReadKey();
		}
	}
}
