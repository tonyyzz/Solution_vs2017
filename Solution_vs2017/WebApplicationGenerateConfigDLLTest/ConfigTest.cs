using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationGenerateConfigDLLTest
{
	public class ConfigTest
	{
		public static string GetStr()
		{
			string str = "a";
#if DEBUG
			str = "DEBUG DLL";
#elif ONLINE
			str = "ONLINE DLL";
#else
			str = "RELEASE DLL";
#endif
			return str;
		}
	}
}
