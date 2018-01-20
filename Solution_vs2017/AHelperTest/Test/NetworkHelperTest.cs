using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest.Test
{
	class NetworkHelperTest
	{
		public void Do()
		{
			var cityInfo = NetworkHelper.GetCityInfo(NetworkHelper.GetOuterNetIP());
		}
	}
}
