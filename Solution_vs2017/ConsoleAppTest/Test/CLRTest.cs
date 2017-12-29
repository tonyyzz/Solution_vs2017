using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class CLRTest
	{
		public void Do()
		{
			Console.WriteLine(Environment.Is64BitOperatingSystem);
			Console.WriteLine(Environment.Is64BitProcess);

			//System.Runtime.ProfileOptimization
			var securityPermission = new SecurityPermission(SecurityPermissionFlag.SkipVerification);
			Console.WriteLine(securityPermission.IsUnrestricted());
			//System.Runtime.InteropServices.
			var fileVersionInfo= System.Diagnostics.FileVersionInfo.GetVersionInfo(@"E:\code\Solution_vs2017\Solution_vs2017\packages\Newtonsoft.Json.10.0.3\lib\net45\Newtonsoft.Json.dll");
			//System.Reflection.AssemblyName
		}
	}
}
