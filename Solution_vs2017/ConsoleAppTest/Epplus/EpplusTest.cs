using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Epplus
{
	class EpplusTest
	{
		//Epplus中给单元格赋值非常简单，两种方法：(ps:Epplus的所有行列数都是以1开始的)
		public void Do()
		{
			//http://blog.csdn.net/ejinxian/article/details/52315950

			string path = $"C:\\Users\\Administrator\\Desktop\\epplus\\{DateTime.Now.Ticks}.xls";
			FileHelper.DeleteIfExists(path);
			using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
			{
				ExcelWorksheet sheet = package.Workbook.Worksheets.Add("test1");
				sheet.Cells["A1"].Value = "名称";//直接指定行列数进行赋值
				
				var cell = sheet.Cells[1, 1, 6, 5];
				cell.Merge = true;

				var style = cell.Style;
				//对齐样式
				style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
				style.VerticalAlignment = ExcelVerticalAlignment.Center;

				//设置单元格字体样式
				style.Font.Bold = true;
				style.Font.Color.SetColor(Color.Blue);
				style.Font.Name = "微软雅黑";
				style.Font.Size = 12;

				//背景样式
				//cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
				//cell.Style.Fill.BackgroundColor.SetColor(Color.Green);

				//边框样式
				style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
				//style.Border.Bottom.Style = ExcelBorderStyle.Thin;
				//style.Border.Bottom.Color.SetColor(Color.Green);

				//设置单元格的宽高
				style.ShrinkToFit = true; //单元格自动适应大小
				sheet.Row(1).Height = 30;
				sheet.Row(1).CustomHeight = true; //自动调整行高
				sheet.Column(1).Width = 15;

				package.Save();
				System.Diagnostics.Process.Start(path);
			}
		}
	}
}
