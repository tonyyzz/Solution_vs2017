using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest._SingletonT
{
	public class Singleton
	{
		private static Singleton Instance = null;
		private Singleton() { }
		private readonly static object obj = new object();
		public static Singleton GetInstance()
		{
			if (Instance == null)
			{
				lock (obj)
				{
					if (Instance == null)
					{
						Instance = new Singleton();
					}
				}
			}
			return Instance;
		}

	}
}
