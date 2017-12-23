using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	public class ThreadPoolInherit
	{
		private static ThreadPoolInherit Instance = null;
		private ThreadPoolInherit() { }
		private ThreadPoolBase<Person> threadPoolBase = new ThreadPoolBase<Person>();
		private readonly static object obj = new object();
		public static ThreadPoolInherit GetInstance()
		{
			if (Instance == null)
			{
				lock (obj)
				{
					if (Instance == null)
					{
						Instance = new ThreadPoolInherit();
					}
				}
			}
			return Instance;
		}
		public void Start()
		{
			threadPoolBase.Start((person) =>
			{

			});
		}
		public void Enqueue(Person person)
		{
			threadPoolBase.Enqueue(person);
		}
	}

	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
