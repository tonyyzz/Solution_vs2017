using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class PathDirectoryTest
	{
		public void Do()
		{
			string path = @"C:\Users\Administrator\Desktop\fileTest\test.txt";
			 var charStr= Path.AltDirectorySeparatorChar;
			//var path= Path.ChangeExtension(@"C:\Users\Administrator\Desktop\fileTest\test.txt", null);
			var newPath= Path.Combine(@"C:\Users", "a");
			var directory= Path.GetDirectoryName(@"C:\Users\Administrator\Desktop\fileTest\test.txt");
			var chs = Path.GetInvalidPathChars();
			 var randomName= Path.GetRandomFileName();
			 var tempFileName= Path.GetTempFileName();
			 var strList=  Directory.EnumerateFiles(@"C:\Users\Administrator\Desktop\fileTest\test.txt");
		}
	}
}
