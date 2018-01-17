using Auction.Utility.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest
{
	class ExpressHelperTest
	{
		public void Do()
		{
			Expression<Func<int, int, int, int>> expr = (x, y, z) => (x + y) / z;
			var result= ExpressUtils.GetValue(expr);
		}
	}
}
