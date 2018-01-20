using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHelperTest
{
	class EnumHelperTest
	{
		public void Do()
		{
			//SystemTypeEnum systemTypeEnum = SystemTypeEnum.Android;
			//var result = systemTypeEnum.GetEnumDesxription((int)systemTypeEnum);
			 var desc= SystemTypeEnum.Android.GetEnumDesxriptionDict();
		}
		enum SystemTypeEnum
		{
			[Description("电脑")]
			PC = 1,
			//[Description("安卓")]
			Android,
			[Description("苹果")]
			IOS,
		}
	}
}
