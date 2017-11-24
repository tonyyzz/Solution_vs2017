using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class DeepCopyTest
	{
		public void Do()
		{
			//深拷贝
			Info info = new Info() { Id = 7 };
			List<Info> li1 = new List<Info>();
			li1.Add(info.DeepCopy());
			List<Info> li2 = new List<Info>();
			li2.Add(info.DeepCopy());
			info.Id = 3;
		}
		private  class Info
		{
			public int Id { get; set; }
		}
	}
}
