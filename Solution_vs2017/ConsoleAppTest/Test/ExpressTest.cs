using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Test
{
	class ExpressTest
	{
		public void Do()
		{
			ParameterExpression pxpr1 = Expression.Parameter(typeof(int), "a");
			ParameterExpression pxpr2 = Expression.Parameter(typeof(int), "b");
			BinaryExpression bxpr = Expression.Multiply(pxpr1, pxpr2);
			var lamExp = Expression.Lambda<Func<int, int, int>>(bxpr, pxpr1, pxpr2);
			var func= lamExp.Compile();
			var result = func(5, 2);
		}
	}
}
